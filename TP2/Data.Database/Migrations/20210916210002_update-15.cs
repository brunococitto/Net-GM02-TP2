using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Comisiones_id_comision",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Materias_id_materia",
                table: "Cursos");

            migrationBuilder.AlterColumn<int>(
                name: "id_materia",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_comision",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Comisiones_id_comision",
                table: "Cursos",
                column: "id_comision",
                principalTable: "Comisiones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Materias_id_materia",
                table: "Cursos",
                column: "id_materia",
                principalTable: "Materias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Comisiones_id_comision",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Materias_id_materia",
                table: "Cursos");

            migrationBuilder.AlterColumn<int>(
                name: "id_materia",
                table: "Cursos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "id_comision",
                table: "Cursos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Comisiones_id_comision",
                table: "Cursos",
                column: "id_comision",
                principalTable: "Comisiones",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Materias_id_materia",
                table: "Cursos",
                column: "id_materia",
                principalTable: "Materias",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
