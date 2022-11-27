using Microsoft.EntityFrameworkCore;

namespace LSIEntities.Entities;

public class LSIDbContext : DbContext
{
    public LSIDbContext(DbContextOptions<LSIDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    public DbSet<Report> Reports { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Premise> Premises { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.Parse("1903e1ee-4665-48fc-8297-c3af340caa18"), FirstName = "Alex", LastName = "Alex" },
            new User { Id = Guid.Parse("16b7e63d-f218-47b8-b771-18ac5fd70318"), FirstName = "Adam", LastName = "Adam" },
            new User { Id = Guid.Parse("1b276976-f737-4103-87cc-ae2b2eb1b42d"), FirstName = "Zico", LastName = "Zico" });

        modelBuilder.Entity<Premise>().HasData(
            new Premise { Id = Guid.Parse("8a3059ae-3be9-4d3b-aca4-ca62e9b975f0"), Name = "Poland" },
            new Premise { Id = Guid.Parse("4d22e86d-7304-446d-b2c1-65a099a15d10"), Name = "Sweden" },
            new Premise { Id = Guid.Parse("1af91fe4-3683-44f9-9f33-53ec727d029e"), Name = "Austria" });

        modelBuilder.Entity<Report>().HasData(
           new Report { Id = Guid.Parse("f40ed0af-fb56-4cc1-a365-fcc9d119a8db"), Name = "Report 1", DateOfExport = DateTime.UtcNow, UserId = Guid.Parse("1903e1ee-4665-48fc-8297-c3af340caa18"), PremiseId = Guid.Parse("8a3059ae-3be9-4d3b-aca4-ca62e9b975f0") },
           new Report { Id = Guid.Parse("c813bcd1-f3af-443a-a491-47ba2e9cb2ce"), Name = "Report 2", DateOfExport = DateTime.UtcNow, UserId = Guid.Parse("16b7e63d-f218-47b8-b771-18ac5fd70318"), PremiseId = Guid.Parse("4d22e86d-7304-446d-b2c1-65a099a15d10") },
           new Report { Id = Guid.Parse("ac933f98-5e06-46a0-bf8b-7872cbb57c11"), Name = "Report 3", DateOfExport = DateTime.UtcNow, UserId = Guid.Parse("1b276976-f737-4103-87cc-ae2b2eb1b42d"), PremiseId = Guid.Parse("1af91fe4-3683-44f9-9f33-53ec727d029e") });

        base.OnModelCreating(modelBuilder);
    }
}