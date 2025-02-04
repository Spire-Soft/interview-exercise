namespace Ticketapi.Models
{
    public class CreateTicketDto
    {
        public int ProjectId { get; set; }
        public required string Description { get; set; }
        public int UserId { get; set; }
    }
}
