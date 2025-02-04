namespace Ticketapi.Models
{
    public class AssignProjectDto
    {
        public int ProjectId { get; set; }
        public List<int> UserIds { get; set; } = new List<int>();
    }
}

