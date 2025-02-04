using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ticketapi.Data;
using Ticketapi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticketapi.Services
{
    public class TicketService
    {
        private readonly ILogger<TicketService> logger;

        public TicketService(ILogger<TicketService> logger)
        {
            this.logger = logger;
        }

        // Helper method to check if Project/Task exists
        // Fetches an entity of the specified type and ID from the database
        private async Task<T?> GetEntityByIdAsync<T>(DbContext db, int id) where T : class
        {
            var entity = await db.Set<T>().FindAsync(id);
            logger.LogInformation("Fetching entity of type {EntityType} with ID {EntityId}.", typeof(T).Name, id);
            return entity;
        }

        // Retrieves a list of tickets along with their project and user details
        public async Task<List<TicketDto>> GetTickets(TicketDbContext db)
        {
            logger.LogInformation("Retrieving tickets.");

            var ticketProjectJoin = db.Tickets
                .Join(db.Projects,
                      ticket => ticket.ProjectId,
                      project => project.Id,
                      (ticket, project) => new { ticket, project });

            var ticketProjectUserJoin = ticketProjectJoin
                .Join(db.Users,
                      tp => tp.ticket.UserId,
                      user => user.Id,
                      (tp, user) => new { tp.ticket, tp.project, user });

            var ticketDtos = await ticketProjectUserJoin
                .Select(tp => new TicketDto
                {
                    Id = tp.ticket.Id,
                    Description = tp.ticket.Description,
                    ProjectName = tp.project.Name,
                    UserName = tp.user.Name,
                    TicketTasks = db.TicketTasks
                        .Where(tt => tt.TicketId == tp.ticket.Id)
                        .Select(tt => new TicketTaskDto
                        {
                            Id = tt.Id,
                            Description = tt.Description,
                            UserName = db.Users.Where(u => u.Id == tt.UserId).Select(u => u.Name).FirstOrDefault() ?? "Unknown User"
                        })
                        .ToList()
                })
                .ToListAsync();

            logger.LogInformation("Tickets retrieved successfully.");
            return ticketDtos;
        }

        // Assigns a ticket to a user by updating the UserId field of the ticket
        public async Task<bool> AssignUserToTicket(TicketDbContext db, int ticketId, int userId)
        {
            var ticket = await GetEntityByIdAsync<Ticket>(db, ticketId);
            var user = await GetEntityByIdAsync<User>(db, userId);

            if (ticket == null || user == null)
            {
                logger.LogWarning("Failed to assign user. Ticket ID: {TicketId}, User ID: {UserId}", ticketId, userId);
                return false;
            }

            ticket.UserId = user.Id;
            await db.SaveChangesAsync();

            logger.LogInformation("User ID {UserId} assigned to ticket ID {TicketId}.", userId, ticketId);
            return true;
        }

        // Assigns a ticket task to a user by updating the UserId field of the ticket task
        public async Task<bool> AssignUserToTicketTask(TicketDbContext db, int ticketTaskId, int userId)
        {
            var ticketTask = await GetEntityByIdAsync<TicketTask>(db, ticketTaskId);
            var user = await GetEntityByIdAsync<User>(db, userId);

            if (ticketTask == null || user == null)
            {
                logger.LogWarning("Failed to assign user to ticket task. Ticket Task ID: {TicketTaskId}, User ID: {UserId}", ticketTaskId, userId);
                return false;
            }

            ticketTask.UserId = user.Id;
            await db.SaveChangesAsync();

            logger.LogInformation("User ID {UserId} assigned to ticket task ID {TicketTaskId}.", userId, ticketTaskId);
            return true;
        }

        // Adds a task to an existing ticket
        public async Task<bool> AddTicketTask(TicketDbContext db, CreateTicketTaskDto createTicketTaskDto)
        {
            var ticket = await GetEntityByIdAsync<Ticket>(db, createTicketTaskDto.TicketId);
            var user = await GetEntityByIdAsync<User>(db, createTicketTaskDto.UserId);

            if (ticket == null || user == null)
            {
                logger.LogWarning("Failed to add ticket task. Ticket ID: {TicketId}, User ID: {UserId}", createTicketTaskDto.TicketId, createTicketTaskDto.UserId);
                return false;
            }

            var ticketTask = new TicketTask
            {
                Description = createTicketTaskDto.Description,
                TicketId = createTicketTaskDto.TicketId,
                UserId = createTicketTaskDto.UserId
            };

            db.TicketTasks.Add(ticketTask);
            await db.SaveChangesAsync();

            logger.LogInformation("Ticket task added to ticket ID {TicketId}.", createTicketTaskDto.TicketId);
            return true;
        }

        // Adds a new ticket to an existing project
        public async Task<bool> AddTicket(TicketDbContext db, CreateTicketDto createTicketDto)
        {
            var project = await GetEntityByIdAsync<Project>(db, createTicketDto.ProjectId);
            var user = await GetEntityByIdAsync<User>(db, createTicketDto.UserId);

            if (project == null || user == null)
            {
                logger.LogWarning("Failed to add ticket. Project ID: {ProjectId}, User ID: {UserId}", createTicketDto.ProjectId, createTicketDto.UserId);
                return false;
            }

            var ticket = new Ticket
            {
                Description = createTicketDto.Description,
                ProjectId = createTicketDto.ProjectId,
                UserId = createTicketDto.UserId
            };

            db.Tickets.Add(ticket);
            await db.SaveChangesAsync();

            logger.LogInformation("Ticket added to project ID {ProjectId}.", createTicketDto.ProjectId);
            return true;
        }
    }
}