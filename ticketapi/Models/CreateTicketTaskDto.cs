namespace Ticketapi.Models
{
    public class CreateTicketTaskDto
    {
        public int TicketId { get; set; }
        public required string Description { get; set; }
        public int UserId { get; set; }
    }
}
