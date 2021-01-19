using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketHelper.Data.Migrations
{
    public partial class AddTrainPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainPrices",
                columns: table => new
                {
                    TrainId = table.Column<int>(nullable: false),
                    StartStationId = table.Column<int>(nullable: false),
                    EndStationId = table.Column<int>(nullable: false),
                    CarriageTypeId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainPrices", x => new { x.TrainId, x.CarriageTypeId, x.StartStationId, x.EndStationId });
                    table.ForeignKey(
                        name: "FK_TrainPrices_CarriageTypes_CarriageTypeId",
                        column: x => x.CarriageTypeId,
                        principalTable: "CarriageTypes",
                        principalColumn: "CarriageTypeId");
                    table.ForeignKey(
                        name: "FK_TrainPrices_Stations_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId");
                    table.ForeignKey(
                        name: "FK_TrainPrices_Stations_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId");
                    table.ForeignKey(
                        name: "FK_TrainPrices_Trains_TrainId",
                        column: x => x.TrainId,
                        principalTable: "Trains",
                        principalColumn: "TrainId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainPrices_CarriageTypeId",
                table: "TrainPrices",
                column: "CarriageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainPrices_EndStationId",
                table: "TrainPrices",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainPrices_StartStationId",
                table: "TrainPrices",
                column: "StartStationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainPrices");
        }
    }
}
