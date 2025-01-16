using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paula_Medeia_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class SalonBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "SalonBranchID",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceDate",
                table: "Service",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "SalonBranch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonBranch", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_SalonBranchID",
                table: "Service",
                column: "SalonBranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_SalonBranch_SalonBranchID",
                table: "Service",
                column: "SalonBranchID",
                principalTable: "SalonBranch",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_SalonBranch_SalonBranchID",
                table: "Service");

            migrationBuilder.DropTable(
                name: "SalonBranch");

            migrationBuilder.DropIndex(
                name: "IX_Service_SalonBranchID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "SalonBranchID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceDate",
                table: "Service");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
