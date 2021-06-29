using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMastersGameApi.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartLocationId",
                table: "Cargos",
                newName: "StartLocation");

            migrationBuilder.AddColumn<int>(
                name: "Destination",
                table: "Cargos",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Cargos");

            migrationBuilder.RenameColumn(
                name: "StartLocation",
                table: "Cargos",
                newName: "StartLocationId");
        }
    }
}
