using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreateCommand_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblExpenditureRequests",
                columns: table => new
                {
                    expenditureRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strRequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    isRejected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblExpenditureRequests", x => x.expenditureRequestId);
                });

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
                name: "tblUserRoles",
                columns: table => new
                {
                    iRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRoles", x => x.iRoleId);
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
                    iLineId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_tbMeasurements_tblProductionLines_iLineId",
                        column: x => x.iLineId,
                        principalTable: "tblProductionLines",
                        principalColumn: "iLineId");
                });

            migrationBuilder.CreateTable(
                name: "tblUsers",
                columns: table => new
                {
                    iUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iRoleId = table.Column<int>(type: "int", nullable: true),
                    RolesiRoleId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_tblUsers_tblUserRoles_RolesiRoleId",
                        column: x => x.RolesiRoleId,
                        principalTable: "tblUserRoles",
                        principalColumn: "iRoleId");
                });

            migrationBuilder.CreateTable(
                name: "tblExpenditureApprovalMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iOrder = table.Column<int>(type: "int", nullable: false),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    isRejected = table.Column<bool>(type: "bit", nullable: false),
                    iUserId = table.Column<int>(type: "int", nullable: true),
                    UseriUserId = table.Column<int>(type: "int", nullable: true),
                    expenditureRequestId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblExpenditureApprovalMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblExpenditureApprovalMembers_tblExpenditureRequests_expenditureRequestId",
                        column: x => x.expenditureRequestId,
                        principalTable: "tblExpenditureRequests",
                        principalColumn: "expenditureRequestId");
                    table.ForeignKey(
                        name: "FK_tblExpenditureApprovalMembers_tblUsers_UseriUserId",
                        column: x => x.UseriUserId,
                        principalTable: "tblUsers",
                        principalColumn: "iUserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblExpenditureApprovalMembers_expenditureRequestId",
                table: "tblExpenditureApprovalMembers",
                column: "expenditureRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_tblExpenditureApprovalMembers_UseriUserId",
                table: "tblExpenditureApprovalMembers",
                column: "UseriUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUsers_RolesiRoleId",
                table: "tblUsers",
                column: "RolesiRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbMeasurements_iLineId",
                table: "tbMeasurements",
                column: "iLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblExpenditureApprovalMembers");

            migrationBuilder.DropTable(
                name: "tbMeasurements");

            migrationBuilder.DropTable(
                name: "tblExpenditureRequests");

            migrationBuilder.DropTable(
                name: "tblUsers");

            migrationBuilder.DropTable(
                name: "tblProductionLines");

            migrationBuilder.DropTable(
                name: "tblUserRoles");
        }
    }
}
