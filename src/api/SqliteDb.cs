

using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

public class SqliteDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Attractions> Attractions { get; set; }
    public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqliteDbContext).Assembly);
    }
}
