namespace Ticketapi;

public interface IModule
{
    void RegisterServices(IServiceCollection services);
    void MapEndpoints(IEndpointRouteBuilder endpoints);
}