using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHelper.Data.Migrations
{
    public partial class AddCarriageTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarriageTypeId",
                table: "Carriages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarriageTypes",
                columns: table => new
                {
                    CarriageTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarriageTypes", x => x.CarriageTypeId);
                });

            migrationBuilder.InsertData(
                table: "CarriageTypes",
                columns: new[] { "CarriageTypeId", "Name" },
                values: new object[] { 1, "Плацкарт" });

            migrationBuilder.InsertData(
                table: "CarriageTypes",
                columns: new[] { "CarriageTypeId", "Name" },
                values: new object[] { 2, "Купе" });

            migrationBuilder.InsertData(
                table: "CarriageTypes",
                columns: new[] { "CarriageTypeId", "Name" },
                values: new object[] { 3, "Люкс" });

            migrationBuilder.CreateIndex(
                name: "IX_Carriages_CarriageTypeId",
                table: "Carriages",
                column: "CarriageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriages_CarriageTypes_CarriageTypeId",
                table: "Carriages",
                column: "CarriageTypeId",
                principalTable: "CarriageTypes",
                principalColumn: "CarriageTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriages_CarriageTypes_CarriageTypeId",
                table: "Carriages");

            migrationBuilder.DropTable(
                name: "CarriageTypes");

            migrationBuilder.DropIndex(
                name: "IX_Carriages_CarriageTypeId",
                table: "Carriages");

            migrationBuilder.DropColumn(
                name: "CarriageTypeId",
                table: "Carriages");
        }
    }
}
