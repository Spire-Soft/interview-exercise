using Ticketapi.Models;

namespace Ticketapi.Data;

public static class Seeder
{
    public static List<User> SeedUsers()
    {
        return
        [
            new () { Id = 1, Name = "Alex" },
            new () { Id = 2, Name = "Bob" },
            new () { Id = 3, Name = "Marco" }
        ];
    }

    public static List<Project> SeedProjects()
    {
        return
        [
            new () { Id = 1, Name = "Project A" },
            new () { Id = 2, Name = "Project B" }
        ];
    }

    public static List<Ticket> SeedTickets()
    {
        return
        [
            new () { Id = 1, Description = "Fix Bug #101", ProjectId = 1, UserId = 2 },
            new () { Id = 2, Description = "Add Feature #202", ProjectId = 1, UserId = 1 },
            new () { Id = 3, Description = "Refactor Code", ProjectId = 2, UserId = 3 }
        ];
    }

    public static List<TicketTask> SeedTicketTasks()
    {
        return
        [
            new () { Id = 1, Description = "Investigate Bug", TicketId = 1, UserId = 1 },
            new () { Id = 2, Description = "Write Unit Tests", TicketId = 2, UserId = 2 }
        ];
    }
}