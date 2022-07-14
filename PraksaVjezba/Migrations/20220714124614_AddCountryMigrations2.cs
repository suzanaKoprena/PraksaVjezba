using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraksaVjezba.Migrations
{
    public partial class AddCountryMigrations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Srbija" },
                    { 2, "Hrvatska" },
                    { 3, "Grcka" },
                    { 4, "Bosna i Hercegovina" },
                    { 5, "Italija" },
                    { 6, "Francuska" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "country",
                keyColumn: "id",
                keyValue: 6);
        }
    }
}
