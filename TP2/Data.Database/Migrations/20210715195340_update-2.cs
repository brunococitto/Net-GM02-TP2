using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "State",
                table: "ModulosUsuarios");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Modulos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "State",
                table: "DocentesCursos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Comisiones");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AlumnoInscripciones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "ModulosUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Modulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Materias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Especialidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "DocentesCursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Comisiones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "AlumnoInscripciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
