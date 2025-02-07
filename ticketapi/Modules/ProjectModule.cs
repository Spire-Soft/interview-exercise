using Ticketapi.Data;
using Ticketapi.Services;

namespace Ticketapi.Modules;

public class ProjectModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/projects",
            async (ProjectService service, TicketDbContext db) =>
            {
                return Results.Json(await service.GetProjects(db));
            });

        endpoints.MapPut("v1/projects/{projectId}/assign/{userId}",
            async (ProjectService service, TicketDbContext db, int projectId, int userId) =>
            {
                try
                {
                    await service.AssignProject(db, userId, projectId);
                    return Results.Ok();
                }
                catch (ArgumentException e)
                {
                    return Results.BadRequest(e.Message);
                }
            });
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ProjectService>();
    }
}