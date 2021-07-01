using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportMastersGameApi.Migrations
{
    public partial class new2s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Deliveries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUser",
                table: "Deliveries",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Deliveries");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
