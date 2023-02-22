using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kompaniyalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompaniyalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mashinalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rangi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yili = table.Column<int>(type: "int", nullable: false),
                    Kompaniya_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mashinalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mashinalar_Kompaniyalar_Kompaniya_Id",
                        column: x => x.Kompaniya_Id,
                        principalTable: "Kompaniyalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mashinalar_Kompaniya_Id",
                table: "Mashinalar",
                column: "Kompaniya_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mashinalar");

            migrationBuilder.DropTable(
                name: "Kompaniyalar");
        }
    }
}
