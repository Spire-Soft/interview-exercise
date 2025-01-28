using Ticketapi.Services;

namespace Ticketapi.Modules;

public class WeatherModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/health", (HealthService service) => {
            return Results.Ok(service.GetHealth());
        });
    }

    public void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<HealthService>();
    }
}