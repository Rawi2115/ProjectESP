using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ESP32BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class ArabicDescriptionsToProvinces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArDescription",
                table: "Provinces",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArDescription",
                value: "عاصمة العراق.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArDescription",
                value: "مدينة ميناء رئيسية في جنوب العراق.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArDescription",
                value: "محافظة تحتوي على الموصل.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArDescription",
                value: "عاصمة إقليم كردستان.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArDescription",
                value: "محافظة في إقليم كردستان.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArDescription",
                value: "محافظة شمالية في كردستان.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArDescription",
                value: "محافظة غنية بالنفط ومتنوعة.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArDescription",
                value: "أكبر محافظة من حيث المساحة.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArDescription",
                value: "محافظة تحتوي على تكريت.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArDescription",
                value: "محافظة شرق بغداد.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 11,
                column: "ArDescription",
                value: "محافظة عاصمتها الكوت.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 12,
                column: "ArDescription",
                value: "محافظة تحتوي على بابل القديمة.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 13,
                column: "ArDescription",
                value: "مدينة مقدسة للشيعة.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 14,
                column: "ArDescription",
                value: "مدينة مقدسة ذات أهمية دينية.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 15,
                column: "ArDescription",
                value: "محافظة عاصمتها الديوانية.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 16,
                column: "ArDescription",
                value: "محافظة صحراوية جنوبية.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 17,
                column: "ArDescription",
                value: "محافظة تحتوي على الناصرية.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 18,
                column: "ArDescription",
                value: "محافظة شرق العراق.");

            migrationBuilder.UpdateData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 19,
                column: "ArDescription",
                value: "أحدث محافظة عراقية.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArDescription",
                table: "Provinces");
        }
    }
}
