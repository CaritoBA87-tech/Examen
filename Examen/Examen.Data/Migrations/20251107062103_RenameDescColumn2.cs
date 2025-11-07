using Microsoft.EntityFrameworkCore.Migrations;

namespace Examen.Data.Migrations
{
    public partial class RenameDescColumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripción", // Old column name
                table: "Articulos", // Table name
                newName: "Descripcion"); // New column name
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
