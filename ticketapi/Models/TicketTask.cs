using System.Text.Json.Serialization;

namespace Ticketapi.Models;

public class TicketTask 
{
    [JsonIgnore]
    public int Id { get; set; }
    public required string Description { get; set; }
    public required int TicketId { get; set; }
    public required int UserId { get; set; }
}