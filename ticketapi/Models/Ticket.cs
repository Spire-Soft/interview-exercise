namespace Ticketapi.Models;

public class Ticket
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }

    public User? User { get; set; }
    public Project? Project { get; set;}
}