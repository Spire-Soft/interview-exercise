using Microsoft.EntityFrameworkCore;
using Ticketapi.Data;
using Ticketapi.DTO;

namespace Ticketapi.Services;

public class ProjectService
{
    public async Task<List<ProjectDto>> GetProjects(TicketDbContext db)
    {
        var projects = await db.Projects.Include(p => p.Users).ToListAsync();
        return [.. projects.Select(p => p.MapToProjectDto())];
        
    }

    public async Task AssignProject(TicketDbContext db, int userId, int projectId)
    {
        var project = await db.Projects.FindAsync(projectId)
            ?? throw new ArgumentException("Project does not exist", nameof(projectId));
        var user = await db.Users.FindAsync(userId)
            ?? throw new ArgumentException("User does not exist", nameof(userId));

        var exists = await db.Projects.Select(p => p.Users.Contains(user)).AnyAsync();
        if (!exists)
        {
            project.Users.Add(user);
            await db.SaveChangesAsync();
        }
    }
}