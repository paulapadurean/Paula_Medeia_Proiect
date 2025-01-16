using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paula_Medeia_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class StylistSpecialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StylistSpecializationID",
                table: "Stylist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StylistSpecialization",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StylistSpecialization", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stylist_StylistSpecializationID",
                table: "Stylist",
                column: "StylistSpecializationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stylist_StylistSpecialization_StylistSpecializationID",
                table: "Stylist",
                column: "StylistSpecializationID",
                principalTable: "StylistSpecialization",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stylist_StylistSpecialization_StylistSpecializationID",
                table: "Stylist");

            migrationBuilder.DropTable(
                name: "StylistSpecialization");

            migrationBuilder.DropIndex(
                name: "IX_Stylist_StylistSpecializationID",
                table: "Stylist");

            migrationBuilder.DropColumn(
                name: "StylistSpecializationID",
                table: "Stylist");
        }
    }
}
