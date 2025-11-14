using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESP32BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class arabicTranslationForAttractions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArDescription",
                table: "Attractions",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArName",
                table: "Attractions",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArDescription",
                table: "Attractions");

            migrationBuilder.DropColumn(
                name: "ArName",
                table: "Attractions");
        }
    }
}
