using Ticketapi.Services;
using Ticketapi.Data;

namespace Ticketapi.Modules;

public class TicketModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/tickets/{userId}",
            async (TicketService service, TicketDbContext db, int userId) =>
            {
                return Results.Json(await service.GetAssignedTickets(db, userId));
            });

        endpoints.MapPost("v1/tickets",
            async (TicketService service, TicketDbContext db, Models.Ticket ticket) =>
            {
                try
                {
                    await service.CreateTicket(db, ticket);
                    return Results.Created();
                }
                catch (ArgumentException e)
                {
                    return Results.BadRequest(e.Message);
                }
            });

        endpoints.MapPatch("v1/tickets/{ticketId}/assign/{userId}",
            async (TicketService service, TicketDbContext db, int ticketId, int userId) =>
            {
                try
                {
                    await service.AssignTicket(db, ticketId, userId);
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
        services.AddSingleton<TicketService>();
    }
}