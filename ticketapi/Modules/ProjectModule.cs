using Ticketapi.Data;
using Ticketapi.Services;
using Ticketapi.Models;
using Microsoft.Extensions.Logging;

namespace Ticketapi.Modules
{
    public class ProjectModule : IModule
    {
        public void MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            // Get projects
            endpoints.MapGet("v1/projects", async (ProjectService service, TicketDbContext db, ILogger<ProjectModule> logger) => {
                logger.LogInformation("Fetching projects.");
                var result = await service.GetProjects(db);
                return Results.Json(result);
            });

            // Assign projects to users
            endpoints.MapPut("v1/projects/assign", async (ProjectService service, TicketDbContext db, AssignProjectDto assignProjectDto, ILogger<ProjectModule> logger) => {
                logger.LogInformation($"Assigning users to project ID {assignProjectDto.ProjectId}.");
                var result = await service.AssignUsersToProject(db, assignProjectDto.ProjectId, assignProjectDto.UserIds);
                return result ? Results.Ok() : Results.BadRequest("Project not found or user IDs invalid");
            });
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ProjectService>();
        }
    }
}