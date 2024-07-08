using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gropkala",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_grop = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gropkala", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kala",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ghimat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mojodi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grop_Kala1id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kala", x => x.ID);
                    table.ForeignKey(
                        name: "FK_kala_Gropkala_grop_Kala1id",
                        column: x => x.grop_Kala1id,
                        principalTable: "Gropkala",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kala_grop_Kala1id",
                table: "kala",
                column: "grop_Kala1id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kala");

            migrationBuilder.DropTable(
                name: "Gropkala");
        }
    }
}
