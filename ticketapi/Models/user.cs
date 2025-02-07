using System.Text.Json.Serialization;

namespace Ticketapi.Models;

public class User
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    [JsonIgnore]
    public List<Project> Projects {get; set; } = [];
    [JsonIgnore]
    public List<Ticket> Tickets { get; set; } = [];
}