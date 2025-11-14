using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Card
{
    public string Uid { get; set; } = null!;
    public int? ProvinceId { get; set; }
    public Province? Province { get; set; }
}
public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("Cards");
        builder.HasKey(c => c.Uid);
        builder.Property(c => c.Uid).IsRequired().HasMaxLength(50);
        builder.HasOne(c => c.Province)
               .WithMany(p => p.Cards)
               .HasForeignKey(c => c.ProvinceId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}