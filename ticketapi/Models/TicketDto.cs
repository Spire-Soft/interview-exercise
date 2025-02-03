namespace Ticketapi.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string ProjectName { get; set; }
        public required string UserName { get; set; }
        public List<TicketTaskDto> TicketTasks { get; set; } = new();
    }

    public class TicketTaskDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string UserName { get; set; } // Add this line
    }
}

