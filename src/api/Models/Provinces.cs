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

        builder.HasData(
    new Province { Id = 1, Name = "Baghdad", ArName = "بغداد", Description = "Capital of Iraq.", ArDescription = "عاصمة العراق.", ImageUrl = "/img/baghdad.jpg", Population = 8000000, Area = 455 },
    new Province { Id = 2, Name = "Basra", ArName = "البصرة", Description = "Major port city in southern Iraq.", ArDescription = "مدينة ميناء رئيسية في جنوب العراق.", ImageUrl = "/img/basra.jpg", Population = 2900000, Area = 19070 },
    new Province { Id = 3, Name = "Nineveh", ArName = "نينوى", Description = "Province containing Mosul.", ArDescription = "محافظة تحتوي على الموصل.", ImageUrl = "/img/nineveh.jpg", Population = 4000000, Area = 37323 },
    new Province { Id = 4, Name = "Erbil", ArName = "أربيل", Description = "Capital of the Kurdistan Region.", ArDescription = "عاصمة إقليم كردستان.", ImageUrl = "/img/erbil.jpg", Population = 2000000, Area = 15074 },
    new Province { Id = 5, Name = "Sulaymaniyah", ArName = "السليمانية", Description = "Kurdistan Region province.", ArDescription = "محافظة في إقليم كردستان.", ImageUrl = "/img/sulaymaniyah.jpg", Population = 2000000, Area = 17023 },
    new Province { Id = 6, Name = "Duhok", ArName = "دهوك", Description = "Northern province of Kurdistan.", ArDescription = "محافظة شمالية في كردستان.", ImageUrl = "/img/duhok.jpg", Population = 1300000, Area = 6553 },
    new Province { Id = 7, Name = "Kirkuk", ArName = "كركوك", Description = "Oil-rich, diverse province.", ArDescription = "محافظة غنية بالنفط ومتنوعة.", ImageUrl = "/img/kirkuk.jpg", Population = 1600000, Area = 9679 },
    new Province { Id = 8, Name = "Anbar", ArName = "الأنبار", Description = "Largest province by area.", ArDescription = "أكبر محافظة من حيث المساحة.", ImageUrl = "/img/anbar.jpg", Population = 1700000, Area = 138501 },
    new Province { Id = 9, Name = "Salah al-Din", ArName = "صلاح الدين", Description = "Province containing Tikrit.", ArDescription = "محافظة تحتوي على تكريت.", ImageUrl = "/img/salahaldin.jpg", Population = 1600000, Area = 24363 },
    new Province { Id = 10, Name = "Diyala", ArName = "ديالى", Description = "Province east of Baghdad.", ArDescription = "محافظة شرق بغداد.", ImageUrl = "/img/diyala.jpg", Population = 1600000, Area = 17685 },
    new Province { Id = 11, Name = "Wasit", ArName = "واسط", Description = "Province with capital Kut.", ArDescription = "محافظة عاصمتها الكوت.", ImageUrl = "/img/wasit.jpg", Population = 1400000, Area = 17153 },
    new Province { Id = 12, Name = "Babil", ArName = "بابل", Description = "Province containing ancient Babylon.", ArDescription = "محافظة تحتوي على بابل القديمة.", ImageUrl = "/img/babil.jpg", Population = 2200000, Area = 5119 },
    new Province { Id = 13, Name = "Karbala", ArName = "كربلاء", Description = "Holy city for Shia Muslims.", ArDescription = "مدينة مقدسة للشيعة.", ImageUrl = "/img/karbala.jpg", Population = 1200000, Area = 5034 },
    new Province { Id = 14, Name = "Najaf", ArName = "النجف", Description = "Holy city with religious significance.", ArDescription = "مدينة مقدسة ذات أهمية دينية.", ImageUrl = "/img/najaf.jpg", Population = 1600000, Area = 28823 },
    new Province { Id = 15, Name = "Qadisiyyah", ArName = "القادسية", Description = "Province with capital Diwaniyah.", ArDescription = "محافظة عاصمتها الديوانية.", ImageUrl = "/img/qadisiyyah.jpg", Population = 1300000, Area = 8153 },
    new Province { Id = 16, Name = "Muthanna", ArName = "المثنى", Description = "Southern desert province.", ArDescription = "محافظة صحراوية جنوبية.", ImageUrl = "/img/muthanna.jpg", Population = 850000, Area = 51740 },
    new Province { Id = 17, Name = "Dhi Qar", ArName = "ذي قار", Description = "Province containing Nasiriyah.", ArDescription = "محافظة تحتوي على الناصرية.", ImageUrl = "/img/dhiqar.jpg", Population = 2100000, Area = 12900 },
    new Province { Id = 18, Name = "Maysan", ArName = "ميسان", Description = "Province east of Iraq.", ArDescription = "محافظة شرق العراق.", ImageUrl = "/img/maysan.jpg", Population = 1100000, Area = 16072 },
    new Province { Id = 19, Name = "Halabja", ArName = "حلبجة", Description = "Newest Iraqi province.", ArDescription = "أحدث محافظة عراقية.", ImageUrl = "/img/halabja.jpg", Population = 400000, Area = 1598 }
);

    }
}

