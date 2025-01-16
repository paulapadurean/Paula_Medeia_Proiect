using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paula_Medeia_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class Stylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StylistID",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stylist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylist", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_StylistID",
                table: "Service",
                column: "StylistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Stylist_StylistID",
                table: "Service",
                column: "StylistID",
                principalTable: "Stylist",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Stylist_StylistID",
                table: "Service");

            migrationBuilder.DropTable(
                name: "Stylist");

            migrationBuilder.DropIndex(
                name: "IX_Service_StylistID",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "StylistID",
                table: "Service");
        }
    }
}
