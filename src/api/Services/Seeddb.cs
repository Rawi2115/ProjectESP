using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class SeedDb
{
    public static async Task Seed(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
        await dbcontext.Database.MigrateAsync();
        await SeedProvinces(dbcontext);
        await SeedCities(dbcontext);
        await SeedAttractions(dbcontext);
        await dbcontext.SaveChangesAsync();
    }
    private static async Task SeedProvinces(SqliteDbContext sqliteDbContext)
    {
        if (sqliteDbContext.Provinces.Any())
        {
            return; // DB has been seeded
        }
        await sqliteDbContext.Provinces.AddRangeAsync(
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
    private static async Task SeedCities(SqliteDbContext sqliteDbContext)
    {
        if (sqliteDbContext.Cities.Any())
        {
            return; // DB has been seeded
        }
    await sqliteDbContext.Cities.AddRangeAsync(
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
    private static async Task SeedAttractions(SqliteDbContext sqliteDbContext)
    {
        if (sqliteDbContext.Attractions.Any())
        {
            return; // DB has been seeded
        }
        await sqliteDbContext.Attractions.AddRangeAsync(
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