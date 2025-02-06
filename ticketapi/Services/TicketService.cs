using Microsoft.EntityFrameworkCore;
using Ticketapi.Data;
using Ticketapi.Models;

namespace Ticketapi.Services;

public class TicketService
{

    public async Task<int> GetTotalTicketCount(TicketDbContext db){
        return await db.Tickets.CountAsync();
    }

    public async Task<List<Ticket>> GetAssignedTickets(TicketDbContext db, int userId)
    {
        // With bad data, our query will yield an empty list instead of an exception
        return await db.Tickets
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task CreateTicket(TicketDbContext db, Ticket ticket)
    {
        _ = await db.Projects.FindAsync(ticket.ProjectId)
            ?? throw new ArgumentException("ProjectId does not exist", nameof(ticket));

        db.Tickets.Add(ticket);
        await db.SaveChangesAsync();
    }

    public async Task AssignTicket(TicketDbContext db, int ticketId, int userId)
    {
        var ticket = await db.Tickets.FindAsync(ticketId)
            ?? throw new ArgumentException("Ticket does not exist", nameof(ticketId));
        _ = await db.Users.FindAsync(userId)
            ?? throw new ArgumentException("User does not exist", nameof(userId));

        ticket.UserId = userId;
        await db.SaveChangesAsync();
    }
}