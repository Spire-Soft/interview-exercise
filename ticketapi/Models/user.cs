namespace Ticketapi.Models;

public class User
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public List<Project> Projects {get; set; } = [];
}