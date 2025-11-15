using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ArName { get; set; } = null!;
    public int ProvinceId { get; set; }
}

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.ArName).IsRequired().HasMaxLength(100);

        builder.Property(c => c.ProvinceId).IsRequired();
        builder.HasOne<Province>()
            .WithMany(p => p.Cities)
            .HasForeignKey(c => c.ProvinceId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
