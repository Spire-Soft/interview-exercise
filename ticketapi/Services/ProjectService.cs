using Microsoft.EntityFrameworkCore;
using Ticketapi.Data;
using Ticketapi.Models;

namespace Ticketapi.Services;

public class ProjectService
{
    public async Task<List<Project>> GetProjects(TicketDbContext db)
    {
        return await db.Projects.ToListAsync();
    }
}