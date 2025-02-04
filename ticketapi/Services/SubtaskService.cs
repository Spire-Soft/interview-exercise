using Microsoft.EntityFrameworkCore;
using Ticketapi.Data;
using Ticketapi.Models;

namespace Ticketapi.Services;

public class SubtaskService
{
    public async Task CreateSubTask(TicketDbContext db, TicketTask ticketTask)
    {
        _ = await db.Tickets.FindAsync(ticketTask.TicketId)
            ?? throw new ArgumentException("TicketId does not exist", nameof(ticketTask));
        _ = await db.Users.FindAsync(ticketTask.UserId)
            ?? throw new ArgumentException("UserId does not exist", nameof(ticketTask));

        db.TicketTasks.Add(ticketTask);
        await db.SaveChangesAsync();
    }

    public async Task AssignSubTask(TicketDbContext db, int subtaskId, int userId)
    {
        var subtask = await db.TicketTasks.FindAsync(subtaskId)
            ?? throw new ArgumentException("Subtask does not exist", nameof(subtaskId));
        _ = await db.Users.FindAsync(userId)
            ?? throw new ArgumentException("User does not exist", nameof(userId));

        subtask.UserId = userId;
        await db.SaveChangesAsync();
    }
}