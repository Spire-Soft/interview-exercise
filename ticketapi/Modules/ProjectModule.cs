using Ticketapi.Data;
using Ticketapi.Services;

namespace Ticketapi.Modules;

public class ProjectModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/projects", async (ProjectService service, TicketDbContext db) => {
            return Results.Json(await service.GetProjects(db));
        });
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<ProjectService>();
    }
}