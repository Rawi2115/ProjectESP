using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Province
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ArDescription { get; set; } = null!;

    public string ImageUrl {get;set;} = null!;

    public int Population { get; set; }

    public double Area { get; set; }

    public ICollection<City> Cities { get; set; } = new List<City>();

    public ICollection<Card> Cards { get; set; } = new List<Card>();
    public ICollection<Attractions> Attractions { get; set; } = new List<Attractions>();
}

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.ToTable("Provinces");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.ArName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        builder.Property(p => p.ArDescription).IsRequired().HasMaxLength(500);
        builder.Property(p => p.ImageUrl).IsRequired();
        builder.Property(p => p.Population).IsRequired();
        builder.Property(p => p.Area).IsRequired();

        

    }
}

