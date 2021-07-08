using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMastersGameApi.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalizationE",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LocalizationN",
                table: "Vehicles");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "Vehicles",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "Vehicles",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "LocalizationE",
                table: "Vehicles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LocalizationN",
                table: "Vehicles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
