using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Habilitado",
                table: "Usuarios",
                newName: "habilitado");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "Usuarios",
                newName: "clave");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Usuarios",
                newName: "apellido");

            migrationBuilder.RenameColumn(
                name: "NombreUsuario",
                table: "Usuarios",
                newName: "nombre_usuario");

            migrationBuilder.RenameColumn(
                name: "IDEspecialidad",
                table: "Planes",
                newName: "id_especialidad");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Planes",
                newName: "desc_plan");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Modulos",
                newName: "desc_modulo");

            migrationBuilder.RenameColumn(
                name: "IDPlan",
                table: "Materias",
                newName: "id_plan");

            migrationBuilder.RenameColumn(
                name: "HSTotales",
                table: "Materias",
                newName: "hs_totales");

            migrationBuilder.RenameColumn(
                name: "HSSemanales",
                table: "Materias",
                newName: "hs_semanales");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Materias",
                newName: "desc_materia");

            migrationBuilder.RenameColumn(
                name: "Cupo",
                table: "Cursos",
                newName: "cupo");

            migrationBuilder.RenameColumn(
                name: "IDMateria",
                table: "Cursos",
                newName: "id_materia");

            migrationBuilder.RenameColumn(
                name: "IDComision",
                table: "Cursos",
                newName: "id_comision");

            migrationBuilder.RenameColumn(
                name: "AnoCalendario",
                table: "Cursos",
                newName: "desc_curso");

            migrationBuilder.AlterColumn<string>(
                name: "cupo",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "anio_calendario",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anio_calendario",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "habilitado",
                table: "Usuarios",
                newName: "Habilitado");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "clave",
                table: "Usuarios",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "apellido",
                table: "Usuarios",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "nombre_usuario",
                table: "Usuarios",
                newName: "NombreUsuario");

            migrationBuilder.RenameColumn(
                name: "id_especialidad",
                table: "Planes",
                newName: "IDEspecialidad");

            migrationBuilder.RenameColumn(
                name: "desc_plan",
                table: "Planes",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "desc_modulo",
                table: "Modulos",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "id_plan",
                table: "Materias",
                newName: "IDPlan");

            migrationBuilder.RenameColumn(
                name: "hs_totales",
                table: "Materias",
                newName: "HSTotales");

            migrationBuilder.RenameColumn(
                name: "hs_semanales",
                table: "Materias",
                newName: "HSSemanales");

            migrationBuilder.RenameColumn(
                name: "desc_materia",
                table: "Materias",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "cupo",
                table: "Cursos",
                newName: "Cupo");

            migrationBuilder.RenameColumn(
                name: "id_materia",
                table: "Cursos",
                newName: "IDMateria");

            migrationBuilder.RenameColumn(
                name: "id_comision",
                table: "Cursos",
                newName: "IDComision");

            migrationBuilder.RenameColumn(
                name: "desc_curso",
                table: "Cursos",
                newName: "AnoCalendario");

            migrationBuilder.AlterColumn<int>(
                name: "Cupo",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
