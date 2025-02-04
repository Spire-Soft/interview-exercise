using Ticketapi.Models;

namespace Ticketapi.DTO;

public static class ProjectMapper
{
    public static ProjectDto MapToProjectDto(this Project entity)
    {
        return new ProjectDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Users = TransformUsers(entity.Users)
        };
    }

    private static List<UserDto> TransformUsers(List<User> users)
    {
        return [.. users.Select(u => new UserDto { Id = u.Id, Name = u.Name })];
    }
}