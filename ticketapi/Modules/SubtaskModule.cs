using Ticketapi.Services;
using Ticketapi.Data;

namespace Ticketapi.Modules;

public class SubtaskModule : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("v1/subtasks",
            async (SubtaskService service, TicketDbContext db, Models.TicketTask subtask) =>
            {
                try
                {
                    await service.CreateSubTask(db, subtask);
                    return Results.Created();
                }
                catch (ArgumentException e)
                {
                    return Results.BadRequest(e.Message);
                }
            });

        endpoints.MapPut("v1/subtasks/{subtaskId}/assign/{userId}",
            async (SubtaskService service, TicketDbContext db, int subtaskId, int userId) =>
            {
                try
                {
                    await service.AssignSubTask(db, subtaskId, userId);
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
        services.AddSingleton<SubtaskService>();
    }
}