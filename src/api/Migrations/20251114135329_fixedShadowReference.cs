using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESP32BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class fixedShadowReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Provinces_ProvinceId1",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ProvinceId1",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ProvinceId1",
                table: "Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinceId1",
                table: "Cards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ProvinceId1",
                table: "Cards",
                column: "ProvinceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Provinces_ProvinceId1",
                table: "Cards",
                column: "ProvinceId1",
                principalTable: "Provinces",
                principalColumn: "Id");
        }
    }
}
