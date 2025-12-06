using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.InfPresistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreateCommand_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProductionLines",
                columns: table => new
                {
                    iLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strLineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductionLines", x => x.iLineId);
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    iUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsers", x => x.iUserId);
                });

            migrationBuilder.CreateTable(
                name: "tbMeasurements",
                columns: table => new
                {
                    iMeasurementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dHumidity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dDepth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bIsWithinSpecification = table.Column<bool>(type: "bit", nullable: false),
                    ProductionLineNavigationiLineId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMeasurements", x => x.iMeasurementID);
                    table.ForeignKey(
                        name: "FK_tbMeasurements_tblProductionLines_ProductionLineNavigationiLineId",
                        column: x => x.ProductionLineNavigationiLineId,
                        principalTable: "tblProductionLines",
                        principalColumn: "iLineId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbMeasurements_ProductionLineNavigationiLineId",
                table: "tbMeasurements",
                column: "ProductionLineNavigationiLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tbMeasurements");

            migrationBuilder.DropTable(
                name: "tblProductionLines");
        }
    }
}
