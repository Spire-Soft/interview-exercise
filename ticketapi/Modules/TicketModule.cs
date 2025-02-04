using Ticketapi.Data;
using Ticketapi.Services;
using Ticketapi.Models;
using Microsoft.Extensions.Logging;

namespace Ticketapi.Modules
{
    public class TicketModule : IModule
    {
        public void MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            // Get Tickets
            endpoints.MapGet("v1/tickets", async (TicketService service, TicketDbContext db, ILogger<TicketModule> logger) => {
                logger.LogInformation("Fetching tickets.");
                var result = await service.GetTickets(db);
                return Results.Json(result);
            });

            // Assign ticket to user
            endpoints.MapPut("v1/tickets/assign", async (TicketService service, TicketDbContext db, AssignTicketDto assignTicketDto, ILogger<TicketModule> logger) => {
                logger.LogInformation($"Assigning user ID {assignTicketDto.UserId} to ticket ID {assignTicketDto.TicketId}.");
                var result = await service.AssignUserToTicket(db, assignTicketDto.TicketId, assignTicketDto.UserId);
                return result ? Results.Ok() : Results.BadRequest("Ticket not found or user ID invalid");
            });

            // Assign ticket task to user
            endpoints.MapPut("v1/tickettasks/assign", async (TicketService service, TicketDbContext db, AssignTicketTaskDto assignTicketTaskDto, ILogger<TicketModule> logger) => {
                logger.LogInformation($"Assigning user ID {assignTicketTaskDto.UserId} to ticket task ID {assignTicketTaskDto.TicketTaskId}.");
                var result = await service.AssignUserToTicketTask(db, assignTicketTaskDto.TicketTaskId, assignTicketTaskDto.UserId);
                return result ? Results.Ok() : Results.BadRequest("Ticket task not found or user ID invalid");
            });

            // Add a ticket task to a ticket
            endpoints.MapPost("v1/tickettasks/add", async (TicketService service, TicketDbContext db, CreateTicketTaskDto createTicketTaskDto, ILogger<TicketModule> logger) => {
                logger.LogInformation($"Adding ticket task to ticket ID {createTicketTaskDto.TicketId}.");
                var result = await service.AddTicketTask(db, createTicketTaskDto);
                return result ? Results.Ok() : Results.BadRequest("Ticket not found or user ID invalid");
            });

            // Add a new ticket to an existing project
            endpoints.MapPost("v1/tickets/add", async (TicketService service, TicketDbContext db, CreateTicketDto createTicketDto, ILogger<TicketModule> logger) => {
                logger.LogInformation($"Adding ticket to project ID {createTicketDto.ProjectId}.");
                var result = await service.AddTicket(db, createTicketDto);
                return result ? Results.Ok() : Results.BadRequest("Project not found or user ID invalid");
            });
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<TicketService>();
        }
    }
}
