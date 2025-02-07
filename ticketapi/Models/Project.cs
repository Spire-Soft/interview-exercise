using System.Text.Json.Serialization;

namespace Ticketapi.Models;

public class Project
{
    [JsonIgnore]
    public required int Id { get; set; }
    public required string Name { get; set; }
    [JsonIgnore]
    public List<User> Users { get; set; } = [];
    [JsonIgnore]
    public List<Ticket> Tickets { get; set; } = [];
}