using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DocentesCursos_IDCurso",
                table: "DocentesCursos",
                column: "IDCurso");

            migrationBuilder.CreateIndex(
                name: "IX_DocentesCursos_IDDocente",
                table: "DocentesCursos",
                column: "IDDocente");

            migrationBuilder.AddForeignKey(
                name: "FK_DocentesCursos_Cursos_IDCurso",
                table: "DocentesCursos",
                column: "IDCurso",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocentesCursos_Personas_IDDocente",
                table: "DocentesCursos",
                column: "IDDocente",
                principalTable: "Personas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocentesCursos_Cursos_IDCurso",
                table: "DocentesCursos");

            migrationBuilder.DropForeignKey(
                name: "FK_DocentesCursos_Personas_IDDocente",
                table: "DocentesCursos");

            migrationBuilder.DropIndex(
                name: "IX_DocentesCursos_IDCurso",
                table: "DocentesCursos");

            migrationBuilder.DropIndex(
                name: "IX_DocentesCursos_IDDocente",
                table: "DocentesCursos");
        }
    }
}
