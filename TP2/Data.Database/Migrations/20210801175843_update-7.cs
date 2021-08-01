using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoInscripciones_Cursos_CursoID",
                table: "AlumnoInscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoInscripciones_Personas_PersonaID",
                table: "AlumnoInscripciones");

            migrationBuilder.DropIndex(
                name: "IX_AlumnoInscripciones_CursoID",
                table: "AlumnoInscripciones");

            migrationBuilder.DropIndex(
                name: "IX_AlumnoInscripciones_PersonaID",
                table: "AlumnoInscripciones");

            migrationBuilder.DropColumn(
                name: "CursoID",
                table: "AlumnoInscripciones");

            migrationBuilder.DropColumn(
                name: "PersonaID",
                table: "AlumnoInscripciones");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoInscripciones_IDAlumno",
                table: "AlumnoInscripciones",
                column: "IDAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoInscripciones_IDCurso",
                table: "AlumnoInscripciones",
                column: "IDCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoInscripciones_Cursos_IDCurso",
                table: "AlumnoInscripciones",
                column: "IDCurso",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoInscripciones_Personas_IDAlumno",
                table: "AlumnoInscripciones",
                column: "IDAlumno",
                principalTable: "Personas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoInscripciones_Cursos_IDCurso",
                table: "AlumnoInscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_AlumnoInscripciones_Personas_IDAlumno",
                table: "AlumnoInscripciones");

            migrationBuilder.DropIndex(
                name: "IX_AlumnoInscripciones_IDAlumno",
                table: "AlumnoInscripciones");

            migrationBuilder.DropIndex(
                name: "IX_AlumnoInscripciones_IDCurso",
                table: "AlumnoInscripciones");

            migrationBuilder.AddColumn<int>(
                name: "CursoID",
                table: "AlumnoInscripciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonaID",
                table: "AlumnoInscripciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoInscripciones_CursoID",
                table: "AlumnoInscripciones",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoInscripciones_PersonaID",
                table: "AlumnoInscripciones",
                column: "PersonaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoInscripciones_Cursos_CursoID",
                table: "AlumnoInscripciones",
                column: "CursoID",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlumnoInscripciones_Personas_PersonaID",
                table: "AlumnoInscripciones",
                column: "PersonaID",
                principalTable: "Personas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
