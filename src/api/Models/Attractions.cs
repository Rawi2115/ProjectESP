using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Attractions
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ArDescription { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public int ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
}

public class AttractionsConfiguration : IEntityTypeConfiguration<Attractions>
{
    public void Configure(EntityTypeBuilder<Attractions> builder)
    {
        builder.ToTable("Attractions");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();
        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Property(a => a.ArName).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Description).IsRequired().HasMaxLength(500);
        builder.Property(a => a.ArDescription).IsRequired().HasMaxLength(500);
        builder.Property(a => a.Location).IsRequired().HasMaxLength(200);
        builder.Property(a => a.ImageUrl).IsRequired();

        builder.HasOne(a => a.Province)
            .WithMany(p => p.Attractions)
            .HasForeignKey(a => a.ProvinceId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}
