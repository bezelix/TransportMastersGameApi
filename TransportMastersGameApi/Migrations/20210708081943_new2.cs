using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMastersGameApi.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnMarket",
                table: "VehicleTemplate",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OnMarket",
                table: "Vehicles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnMarket",
                table: "VehicleTemplate");

            migrationBuilder.DropColumn(
                name: "OnMarket",
                table: "Vehicles");
        }
    }
}
