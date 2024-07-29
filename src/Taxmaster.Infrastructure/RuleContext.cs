using Microsoft.EntityFrameworkCore;

namespace Taxmaster.Infrastructure;

public class RuleContext : DbContext
{
    public RuleContext(DbContextOptions<RuleContext> options) : base(options) { }
    
    public DbSet<DbMunicipality> Municipalities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<DbMunicipality>()
            .HasMany(m => m.Rules)
            .WithOne(r => r.Municipality)
            .HasForeignKey(r => r.MunicipalityId)
            .OnDelete(DeleteBehavior.Cascade); // Optional: Specifies the delete behavior

        // Seed data for DbMunicipality
        builder.Entity<DbMunicipality>().HasData(
            new DbMunicipality { Id = "copenhagen" },
            new DbMunicipality { Id = "aarhus" }
        );

        var pop = new Populator();
        int times = 20;
        var data = new List<DbDateRule>();
        data.AddRange(pop.GetRecurringDateRules("copenhagen", 0.2m, new DateOnly(2020, 1, 1), new DateOnly(2021, 1, 1), times));
        data.AddRange(pop.GetRecurringDateRules("copenhagen", 0.4m, new DateOnly(2020, 5, 1), new DateOnly(2020, 6, 1), times));
        data.AddRange(pop.GetRecurringDateRules("copenhagen", 0.1m, new DateOnly(2020, 1, 1), new DateOnly(2020, 1, 2), times));
        data.AddRange(pop.GetRecurringDateRules("copenhagen", 0.1m, new DateOnly(2020, 12, 25), new DateOnly(2020, 12, 26), times));
        // Seed data for DbRule
        builder.Entity<DbDateRule>().HasData(data);

        base.OnModelCreating(builder);
    }
}

public class DbMunicipality
{
    public required string Id { get; set; }
    public ICollection<DbDateRule> Rules {get; set; } = [];
}

public class DbDateRule
{
    public int Id { get; set; }
    public decimal TaxRate { get; set; }
    public string MunicipalityId { get; set; } = null!;
    public DbMunicipality Municipality { get; set; } = null!;
    public DateTime UtcStartTime { get; set; }
    public DateTime UtcEndTime { get; set; }
}
