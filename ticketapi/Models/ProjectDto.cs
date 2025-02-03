namespace Ticketapi.Models
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required List<UserDto> Users { get; set; }
    }
}