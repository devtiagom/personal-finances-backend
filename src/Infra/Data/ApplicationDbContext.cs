using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PersonalFinances.src.Domain.Transactions;

namespace PersonalFinances.src.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    private const int DEFAULT_MODELS_TEXT_MAX_LENGTH = 100;
    private const int TRANSACTION_MODEL_NOTE_MAX_LENGTH = 255;

    public DbSet<Income> Incomes { get; set; }
    public DbSet<Bill> Bills { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Income>()
            .Property(i => i.Name)
            .IsRequired();
        builder.Entity<Income>()
            .Property(i => i.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,4)");
        builder.Entity<Income>()
            .Property(i => i.DueDate)
            .IsRequired();
        builder.Entity<Income>()
            .Property(i => i.Description)
            .IsRequired(false);
        builder.Entity<Income>()
            .Property(i => i.Note)
            .IsRequired(false);
        builder.Entity<Income>()
            .Property(i => i.Note)
            .HasMaxLength(TRANSACTION_MODEL_NOTE_MAX_LENGTH);

        builder.Entity<Bill>()
            .Property(i => i.Name)
            .IsRequired();
        builder.Entity<Bill>()
            .Property(i => i.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,4)");
        builder.Entity<Bill>()
            .Property(i => i.DueDate)
            .IsRequired();
        builder.Entity<Bill>()
            .Property(i => i.Description)
            .IsRequired(false);
        builder.Entity<Bill>()
            .Property(i => i.Note)
            .IsRequired(false);
        builder.Entity<Bill>()
            .Property(i => i.Note)
            .HasMaxLength(TRANSACTION_MODEL_NOTE_MAX_LENGTH);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(DEFAULT_MODELS_TEXT_MAX_LENGTH);
    }
}

public class FinancesDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=FinancesDb;User Id=sa;Password=1q2w3e4r@#$;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
