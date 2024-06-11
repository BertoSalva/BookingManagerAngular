using Microsoft.EntityFrameworkCore;

namespace gateway;

public class BookingDbContext(DbContextOptions<BookingDbContext> options) : DbContext(options)
{
    public DbSet<Parent> Parent { get; set; }
    public DbSet<Child> Child { get; set; }
    public DbSet<Psychologist> Psychologist { get; set; }
    public DbSet<BookingRequest> BookingRequest { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Psychologist>()
            .HasData(
                new Psychologist { PsychologistID = 1, PsychologistName = "Psychologist 1", },
                new Psychologist { PsychologistID = 2, PsychologistName = "Psychologist 2", }
            );

        builder
            .Entity<Parent>()
            .HasData(
                new Parent { ParentID = 1, ParentName = "Parent 1", },
                new Parent { ParentID = 2, ParentName = "Parent 2", }
            );

        builder
            .Entity<Child>()
            .HasData(
                new Child { ChildID = 1, ChildName = "Child 1", },
                new Child { ChildID = 2, ChildName = "Child 2", }
            );

        base.OnModelCreating(builder);
    }
}
