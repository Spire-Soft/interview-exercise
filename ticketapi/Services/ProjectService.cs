using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ticketapi.Data;
using Ticketapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketapi.Services
{
    public class ProjectService
    {
        private readonly ILogger<ProjectService> logger;

        public ProjectService(ILogger<ProjectService> logger)
        {
            this.logger = logger;
        }

        // Retrieves a list of projects along with their users.
        public async Task<List<ProjectDto>> GetProjects(TicketDbContext db)
        {
            logger.LogInformation("Retrieving projects.");

            var projects = await db.Projects
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Users = p.Users.Select(u => new UserDto
                    {
                        Id = u.Id,
                        Name = u.Name
                    }).ToList()
                }).ToListAsync();

            logger.LogInformation("Projects retrieved successfully.");
            return projects;
        }

        // Assigns a list of users to a project.
        public async Task<bool> AssignUsersToProject(TicketDbContext db, int projectId, List<int> userIds)
        {
            logger.LogInformation("Assigning users to project ID {ProjectId}.", projectId);

            var project = await db.Projects.Include(p => p.Users).FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null)
            {
                logger.LogWarning("Project with ID {ProjectId} not found.", projectId);
                return false;
            }

            var users = await db.Users.Where(u => userIds.Contains(u.Id)).ToListAsync();

            if (users.Count != userIds.Count)
            {
                logger.LogWarning("One or more user IDs not found for project ID {ProjectId}.", projectId);
                return false;
            }

            foreach (var user in users)
            {
                logger.LogInformation("Adding user ID {UserId} to project ID {ProjectId}.", user.Id, projectId);
                project.Users.Add(user);
            }

            await db.SaveChangesAsync();
            logger.LogInformation("Users assigned to project ID {ProjectId} successfully. User IDs: {UserIds}", projectId, string.Join(", ", userIds));
            return true;
        }
    }
}

