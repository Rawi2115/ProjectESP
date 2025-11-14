using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESP32BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class attractionSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attractions",
                columns: new[] { "Id", "ArDescription", "ArName", "Description", "ImageUrl", "Location", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "سوق الكتب التاريخي والشارع الثقافي في بغداد.", "شارع المتنبي", "Historic book market and cultural street in Baghdad.", "/img/attractions/baghdad_mutanabbi.jpg", "Baghdad", "Al-Mutanabbi Street", 1 },
                    { 2, "كورنيش وشاطئ منطقة ميناء البصرة.", "كورنيش شط العرب", "Riverside promenade and port area in Basra.", "/img/attractions/basra_shatt.jpg", "Basra", "Shatt al-Arab Promenade", 2 },
                    { 3, "قلعة قديمة تطل على الموصل ونهر دجلة.", "قلعة الموصل", "Ancient citadel overlooking Mosul and the Tigris.", "/img/attractions/mosul_citadel.jpg", "Mosul", "Mosul Citadel", 3 },
                    { 4, "قلعة مدرجة في لائحة اليونسكو وسط أربيل.", "قلعة أربيل", "UNESCO-listed citadel in the heart of Erbil.", "/img/attractions/erbil_citadel.jpg", "Erbil", "Erbil Citadel", 4 },
                    { 5, "متحف ونصب تذكاري تاريخي في السليمانية.", "أمنا سوراكا", "Historical museum and memorial in Sulaymaniyah.", "/img/attractions/sulaymaniyah_amna.jpg", "Sulaymaniyah", "Amna Suraka", 5 },
                    { 6, "سد ومنطقة نزهة خلابة قرب دهوك.", "سد دهوك", "Scenic dam and picnic area near Duhok.", "/img/attractions/duhok_dam.jpg", "Duhok", "Duhok Dam", 6 },
                    { 7, "قلعة تاريخية ومنطقة المدينة القديمة في كركوك.", "قلعة كركوك", "Historic citadel and old city area in Kirkuk.", "/img/attractions/kirkuk_citadel.jpg", "Kirkuk", "Kirkuk Citadel", 7 },
                    { 8, "مستنقعات واسعة تقدم رحلات طبيعية.", "أهوار الأنبار", "Vast marshlands and wetlands offering nature excursions.", "/img/attractions/anbar_marshes.jpg", "Anbar", "Anbar Marshes", 8 },
                    { 9, "مواقع تاريخية ومناطق على الواجهة النهريّة حول تكريت.", "قلعة تكريت", "Historical sites and riverfront areas around Tikrit.", "/img/attractions/tikrit_castle.jpg", "Tikrit", "Tikrit Castle", 9 },
                    { 10, "أسواق تقليدية وواجهة نهرية في محافظة ديالى.", "الحي التاريخي خانقين", "Traditional markets and riverside in Diyala governorate.", "/img/attractions/diyala_khanaqin.jpg", "Diyala", "Khanaqin Historic Quarter", 10 },
                    { 11, "الحي التاريخي والواجهة النهرية في واسط.", "المدينة القديمة الكوت", "Historical district and riverside in Wasit.", "/img/attractions/wasit_kut.jpg", "Wasit", "Kut Old Town", 11 },
                    { 12, "أطلال بابل القديمة قرب الحلة الحديثة.", "بابل الأثرية", "Ruins of ancient Babylon near modern-day Hillah.", "/img/attractions/babil_babylon.jpg", "Babil", "Ancient Babylon", 12 },
                    { 13, "موقع حج رئيسي وضريح مقدس في كربلاء.", "ضريح الإمام الحسين", "Major pilgrimage site and holy shrine in Karbala.", "/img/attractions/karbala_shrine.jpg", "Karbala", "Imam Husayn Shrine", 13 },
                    { 14, "ضريح مقدس ومركز حج في النجف.", "ضريح الإمام علي", "Holy shrine and pilgrimage center in Najaf.", "/img/attractions/najaf_shrine.jpg", "Najaf", "Imam Ali Shrine", 14 },
                    { 15, "حدائق محلية ومناطق تاريخية في القادسية.", "حدائق الديوانية", "Local parks and historical areas in Qadisiyyah.", "/img/attractions/qadisiyyah_gardens.jpg", "Qadisiyyah", "Diwaniyah Gardens", 15 },
                    { 16, "مناظر صحراوية ومواقع أثرية في المثنى.", "منطقة صحراء المثنى", "Desert landscapes and archaeological sites in Muthanna.", "/img/attractions/muthanna_desert.jpg", "Muthanna", "Sami al-Sabhan Desert Area", 16 },
                    { 17, "الأهوار الميسوبوتامية ومواقع ثقافية في ذي قار.", "مستنقعات الناصرية", "Mesopotamian marshes and cultural sites in Dhi Qar.", "/img/attractions/dhiqar_marshes.jpg", "Dhi Qar", "Nasiriyah Marshlands", 17 },
                    { 18, "كورنيش و أسواق في مدينة العمارة بمحافظة ميسان.", "كورنيش العمارة", "Riverside promenade and marketplaces in Maysan.", "/img/attractions/maysan_amarah.jpg", "Maysan", "Amarah Waterfront", 18 },
                    { 19, "حديقة نصب تذكاري ومتحف في محافظة حلبجة.", "حديقة ذكرى حلبجة", "Memorial park and museum in Halabja province.", "/img/attractions/halabja_memorial.jpg", "Halabja", "Halabja Memorial Park", 19 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Attractions",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
