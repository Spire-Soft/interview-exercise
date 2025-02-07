namespace Ticketapi.DTO;

public class TicketDto {
    public required int Id { get; set; }
    public required string Description { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}