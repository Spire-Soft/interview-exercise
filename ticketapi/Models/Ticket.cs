using System.Text.Json.Serialization;

namespace Ticketapi.Models;

public class Ticket
{
    [JsonIgnore]
    public int Id { get; set; }
    public required string Description { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    [JsonIgnore]
    public User? User { get; set; }
    [JsonIgnore]
    public Project? Project { get; set;}
}