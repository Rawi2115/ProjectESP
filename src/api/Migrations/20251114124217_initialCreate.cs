using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ESP32BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ArName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Population = table.Column<int>(type: "INTEGER", nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Uid = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ProvinceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Cards_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ArName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProvinceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "ArName", "Area", "Description", "ImageUrl", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "بغداد", 455.0, "Capital of Iraq.", "/img/baghdad.jpg", "Baghdad", 8000000 },
                    { 2, "البصرة", 19070.0, "Major port city in southern Iraq.", "/img/basra.jpg", "Basra", 2900000 },
                    { 3, "نينوى", 37323.0, "Province containing Mosul.", "/img/nineveh.jpg", "Nineveh", 4000000 },
                    { 4, "أربيل", 15074.0, "Capital of the Kurdistan Region.", "/img/erbil.jpg", "Erbil", 2000000 },
                    { 5, "السليمانية", 17023.0, "Kurdistan Region province.", "/img/sulaymaniyah.jpg", "Sulaymaniyah", 2000000 },
                    { 6, "دهوك", 6553.0, "Northern province of Kurdistan.", "/img/duhok.jpg", "Duhok", 1300000 },
                    { 7, "كركوك", 9679.0, "Oil-rich, diverse province.", "/img/kirkuk.jpg", "Kirkuk", 1600000 },
                    { 8, "الأنبار", 138501.0, "Largest province by area.", "/img/anbar.jpg", "Anbar", 1700000 },
                    { 9, "صلاح الدين", 24363.0, "Province containing Tikrit.", "/img/salahaldin.jpg", "Salah al-Din", 1600000 },
                    { 10, "ديالى", 17685.0, "Province east of Baghdad.", "/img/diyala.jpg", "Diyala", 1600000 },
                    { 11, "واسط", 17153.0, "Province with capital Kut.", "/img/wasit.jpg", "Wasit", 1400000 },
                    { 12, "بابل", 5119.0, "Province containing ancient Babylon.", "/img/babil.jpg", "Babil", 2200000 },
                    { 13, "كربلاء", 5034.0, "Holy city for Shia Muslims.", "/img/karbala.jpg", "Karbala", 1200000 },
                    { 14, "النجف", 28823.0, "Holy city with religious significance.", "/img/najaf.jpg", "Najaf", 1600000 },
                    { 15, "القادسية", 8153.0, "Province with capital Diwaniyah.", "/img/qadisiyyah.jpg", "Qadisiyyah", 1300000 },
                    { 16, "المثنى", 51740.0, "Southern desert province.", "/img/muthanna.jpg", "Muthanna", 850000 },
                    { 17, "ذي قار", 12900.0, "Province containing Nasiriyah.", "/img/dhiqar.jpg", "Dhi Qar", 2100000 },
                    { 18, "ميسان", 16072.0, "Province east of Iraq.", "/img/maysan.jpg", "Maysan", 1100000 },
                    { 19, "حلبجة", 1598.0, "Newest Iraqi province.", "/img/halabja.jpg", "Halabja", 400000 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "ArName", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "بغداد", "Baghdad", 1 },
                    { 2, "البصرة", "Basra", 2 },
                    { 3, "الزبير", "Az Zubayr", 2 },
                    { 4, "الموصل", "Mosul", 3 },
                    { 5, "تلعفر", "Tal Afar", 3 },
                    { 6, "أربيل", "Erbil", 4 },
                    { 7, "سوران", "Soran", 4 },
                    { 8, "السليمانية", "Sulaymaniyah", 5 },
                    { 9, "چمچمال", "Chamchamal", 5 },
                    { 10, "دهوك", "Duhok", 6 },
                    { 11, "زاخو", "Zakho", 6 },
                    { 12, "كركوك", "Kirkuk", 7 },
                    { 13, "الرمادي", "Ramadi", 8 },
                    { 14, "الفلوجة", "Fallujah", 8 },
                    { 15, "تكريت", "Tikrit", 9 },
                    { 16, "بعقوبة", "Baqubah", 10 },
                    { 17, "الكوت", "Kut", 11 },
                    { 18, "الحلة", "Hilla", 12 },
                    { 19, "كربلاء", "Karbala", 13 },
                    { 20, "النجف", "Najaf", 14 },
                    { 21, "الديوانية", "Diwaniyah", 15 },
                    { 22, "السماوة", "Samawah", 16 },
                    { 23, "الناصرية", "Nasiriyah", 17 },
                    { 24, "العمارة", "Amarah", 18 },
                    { 25, "حلبجة", "Halabja", 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ProvinceId",
                table: "Cards",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
