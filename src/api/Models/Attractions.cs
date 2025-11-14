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
        builder.HasData(
            new Attractions { Id = 1,  Name = "Al-Mutanabbi Street", ArName = "شارع المتنبي", Description = "Historic book market and cultural street in Baghdad.", ArDescription = "سوق الكتب التاريخي والشارع الثقافي في بغداد.", Location = "Baghdad", ImageUrl = "/img/attractions/baghdad_mutanabbi.jpg", ProvinceId = 1 },
            new Attractions { Id = 2,  Name = "Shatt al-Arab Promenade", ArName = "كورنيش شط العرب", Description = "Riverside promenade and port area in Basra.", ArDescription = "كورنيش وشاطئ منطقة ميناء البصرة.", Location = "Basra", ImageUrl = "/img/attractions/basra_shatt.jpg", ProvinceId = 2 },
            new Attractions { Id = 3,  Name = "Mosul Citadel", ArName = "قلعة الموصل", Description = "Ancient citadel overlooking Mosul and the Tigris.", ArDescription = "قلعة قديمة تطل على الموصل ونهر دجلة.", Location = "Mosul", ImageUrl = "/img/attractions/mosul_citadel.jpg", ProvinceId = 3 },
            new Attractions { Id = 4,  Name = "Erbil Citadel", ArName = "قلعة أربيل", Description = "UNESCO-listed citadel in the heart of Erbil.", ArDescription = "قلعة مدرجة في لائحة اليونسكو وسط أربيل.", Location = "Erbil", ImageUrl = "/img/attractions/erbil_citadel.jpg", ProvinceId = 4 },
            new Attractions { Id = 5,  Name = "Amna Suraka", ArName = "أمنا سوراكا", Description = "Historical museum and memorial in Sulaymaniyah.", ArDescription = "متحف ونصب تذكاري تاريخي في السليمانية.", Location = "Sulaymaniyah", ImageUrl = "/img/attractions/sulaymaniyah_amna.jpg", ProvinceId = 5 },
            new Attractions { Id = 6,  Name = "Duhok Dam", ArName = "سد دهوك", Description = "Scenic dam and picnic area near Duhok.", ArDescription = "سد ومنطقة نزهة خلابة قرب دهوك.", Location = "Duhok", ImageUrl = "/img/attractions/duhok_dam.jpg", ProvinceId = 6 },
            new Attractions { Id = 7,  Name = "Kirkuk Citadel", ArName = "قلعة كركوك", Description = "Historic citadel and old city area in Kirkuk.", ArDescription = "قلعة تاريخية ومنطقة المدينة القديمة في كركوك.", Location = "Kirkuk", ImageUrl = "/img/attractions/kirkuk_citadel.jpg", ProvinceId = 7 },
            new Attractions { Id = 8,  Name = "Anbar Marshes", ArName = "أهوار الأنبار", Description = "Vast marshlands and wetlands offering nature excursions.", ArDescription = "مستنقعات واسعة تقدم رحلات طبيعية.", Location = "Anbar", ImageUrl = "/img/attractions/anbar_marshes.jpg", ProvinceId = 8 },
            new Attractions { Id = 9,  Name = "Tikrit Castle", ArName = "قلعة تكريت", Description = "Historical sites and riverfront areas around Tikrit.", ArDescription = "مواقع تاريخية ومناطق على الواجهة النهريّة حول تكريت.", Location = "Tikrit", ImageUrl = "/img/attractions/tikrit_castle.jpg", ProvinceId = 9 },
            new Attractions { Id = 10, Name = "Khanaqin Historic Quarter", ArName = "الحي التاريخي خانقين", Description = "Traditional markets and riverside in Diyala governorate.", ArDescription = "أسواق تقليدية وواجهة نهرية في محافظة ديالى.", Location = "Diyala", ImageUrl = "/img/attractions/diyala_khanaqin.jpg", ProvinceId = 10 },
            new Attractions { Id = 11, Name = "Kut Old Town", ArName = "المدينة القديمة الكوت", Description = "Historical district and riverside in Wasit.", ArDescription = "الحي التاريخي والواجهة النهرية في واسط.", Location = "Wasit", ImageUrl = "/img/attractions/wasit_kut.jpg", ProvinceId = 11 },
            new Attractions { Id = 12, Name = "Ancient Babylon", ArName = "بابل الأثرية", Description = "Ruins of ancient Babylon near modern-day Hillah.", ArDescription = "أطلال بابل القديمة قرب الحلة الحديثة.", Location = "Babil", ImageUrl = "/img/attractions/babil_babylon.jpg", ProvinceId = 12 },
            new Attractions { Id = 13, Name = "Imam Husayn Shrine", ArName = "ضريح الإمام الحسين", Description = "Major pilgrimage site and holy shrine in Karbala.", ArDescription = "موقع حج رئيسي وضريح مقدس في كربلاء.", Location = "Karbala", ImageUrl = "/img/attractions/karbala_shrine.jpg", ProvinceId = 13 },
            new Attractions { Id = 14, Name = "Imam Ali Shrine", ArName = "ضريح الإمام علي", Description = "Holy shrine and pilgrimage center in Najaf.", ArDescription = "ضريح مقدس ومركز حج في النجف.", Location = "Najaf", ImageUrl = "/img/attractions/najaf_shrine.jpg", ProvinceId = 14 },
            new Attractions { Id = 15, Name = "Diwaniyah Gardens", ArName = "حدائق الديوانية", Description = "Local parks and historical areas in Qadisiyyah.", ArDescription = "حدائق محلية ومناطق تاريخية في القادسية.", Location = "Qadisiyyah", ImageUrl = "/img/attractions/qadisiyyah_gardens.jpg", ProvinceId = 15 },
            new Attractions { Id = 16, Name = "Sami al-Sabhan Desert Area", ArName = "منطقة صحراء المثنى", Description = "Desert landscapes and archaeological sites in Muthanna.", ArDescription = "مناظر صحراوية ومواقع أثرية في المثنى.", Location = "Muthanna", ImageUrl = "/img/attractions/muthanna_desert.jpg", ProvinceId = 16 },
            new Attractions { Id = 17, Name = "Nasiriyah Marshlands", ArName = "مستنقعات الناصرية", Description = "Mesopotamian marshes and cultural sites in Dhi Qar.", ArDescription = "الأهوار الميسوبوتامية ومواقع ثقافية في ذي قار.", Location = "Dhi Qar", ImageUrl = "/img/attractions/dhiqar_marshes.jpg", ProvinceId = 17 },
            new Attractions { Id = 18, Name = "Amarah Waterfront", ArName = "كورنيش العمارة", Description = "Riverside promenade and marketplaces in Maysan.", ArDescription = "كورنيش و أسواق في مدينة العمارة بمحافظة ميسان.", Location = "Maysan", ImageUrl = "/img/attractions/maysan_amarah.jpg", ProvinceId = 18 },
            new Attractions { Id = 19, Name = "Halabja Memorial Park", ArName = "حديقة ذكرى حلبجة", Description = "Memorial park and museum in Halabja province.", ArDescription = "حديقة نصب تذكاري ومتحف في محافظة حلبجة.", Location = "Halabja", ImageUrl = "/img/attractions/halabja_memorial.jpg", ProvinceId = 19 }
        );
    }
}
