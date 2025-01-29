using Microsoft.EntityFrameworkCore;
using Ticketapi.Models;

namespace Ticketapi.Data;

public class TicketDbContext(DbContextOptions<TicketDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketTask> TicketTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>()
            .HasMany(p => p.Users)
            .WithMany(u => u.Projects)
            .UsingEntity(j =>
            {
                j.ToTable("ProjectsUsers");
                j.HasData(
                    new { ProjectsId = 1, UsersId = 2 },
                    new { ProjectsId = 1, UsersId = 1 },
                    new { ProjectsId = 2, UsersId = 3 }
                );
            });
        
        modelBuilder.Entity<Project>().HasData(Seeder.SeedProjects());
        modelBuilder.Entity<User>().HasData(Seeder.SeedUsers());
        modelBuilder.Entity<Ticket>().HasData(Seeder.SeedTickets());
        modelBuilder.Entity<TicketTask>().HasData(Seeder.SeedTicketTasks());

    }
}