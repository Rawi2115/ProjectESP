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

        builder.HasData(
            // Baghdad
            new City { Id = 1, Name = "Baghdad", ArName = "بغداد", ProvinceId = 1 },

            // Basra
            new City { Id = 2, Name = "Basra", ArName = "البصرة", ProvinceId = 2 },
            new City { Id = 3, Name = "Az Zubayr", ArName = "الزبير", ProvinceId = 2 },

            // Nineveh
            new City { Id = 4, Name = "Mosul", ArName = "الموصل", ProvinceId = 3 },
            new City { Id = 5, Name = "Tal Afar", ArName = "تلعفر", ProvinceId = 3 },

            // Erbil
            new City { Id = 6, Name = "Erbil", ArName = "أربيل", ProvinceId = 4 },
            new City { Id = 7, Name = "Soran", ArName = "سوران", ProvinceId = 4 },

            // Sulaymaniyah
            new City { Id = 8, Name = "Sulaymaniyah", ArName = "السليمانية", ProvinceId = 5 },
            new City { Id = 9, Name = "Chamchamal", ArName = "چمچمال", ProvinceId = 5 },

            // Duhok
            new City { Id = 10, Name = "Duhok", ArName = "دهوك", ProvinceId = 6 },
            new City { Id = 11, Name = "Zakho", ArName = "زاخو", ProvinceId = 6 },

            // Kirkuk
            new City { Id = 12, Name = "Kirkuk", ArName = "كركوك", ProvinceId = 7 },

            // Anbar
            new City { Id = 13, Name = "Ramadi", ArName = "الرمادي", ProvinceId = 8 },
            new City { Id = 14, Name = "Fallujah", ArName = "الفلوجة", ProvinceId = 8 },

            // Salah al-Din
            new City { Id = 15, Name = "Tikrit", ArName = "تكريت", ProvinceId = 9 },

            // Diyala
            new City { Id = 16, Name = "Baqubah", ArName = "بعقوبة", ProvinceId = 10 },

            // Wasit
            new City { Id = 17, Name = "Kut", ArName = "الكوت", ProvinceId = 11 },

            // Babil
            new City { Id = 18, Name = "Hilla", ArName = "الحلة", ProvinceId = 12 },

            // Karbala
            new City { Id = 19, Name = "Karbala", ArName = "كربلاء", ProvinceId = 13 },

            // Najaf
            new City { Id = 20, Name = "Najaf", ArName = "النجف", ProvinceId = 14 },

            // Qadisiyyah
            new City { Id = 21, Name = "Diwaniyah", ArName = "الديوانية", ProvinceId = 15 },

            // Muthanna
            new City { Id = 22, Name = "Samawah", ArName = "السماوة", ProvinceId = 16 },

            // Dhi Qar
            new City { Id = 23, Name = "Nasiriyah", ArName = "الناصرية", ProvinceId = 17 },

            // Maysan
            new City { Id = 24, Name = "Amarah", ArName = "العمارة", ProvinceId = 18 },

            // Halabja
            new City { Id = 25, Name = "Halabja", ArName = "حلبجة", ProvinceId = 19 }
        );
    }
}
