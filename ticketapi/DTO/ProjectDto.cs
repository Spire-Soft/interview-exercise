namespace Ticketapi.DTO;

public class ProjectDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required List<UserDto> Users { get; set; }
}