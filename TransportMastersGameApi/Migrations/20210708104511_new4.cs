using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMastersGameApi.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleMileage",
                table: "VehicleTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleMileage",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleMileage",
                table: "VehicleTemplate");

            migrationBuilder.DropColumn(
                name: "VehicleMileage",
                table: "Vehicles");
        }
    }
}
