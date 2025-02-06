namespace Ticketapi.Models;

public class Project
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public List<User> Users { get; set; } = [];
    public List<Ticket> Tickets { get; set; } = [];
}