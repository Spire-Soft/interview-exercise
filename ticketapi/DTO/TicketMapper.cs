using Ticketapi.Models;

namespace Ticketapi.DTO;

public static class TicketMapper {

    public static TicketDto MapToTicketDto(this Ticket entity) 
    {
        return new TicketDto 
        {
            Id = entity.Id,
            Description = entity.Description,
            ProjectName = entity.Project?.Name ?? string.Empty,
            UserName = entity.User?.Name ?? string.Empty 
        };
    }

}