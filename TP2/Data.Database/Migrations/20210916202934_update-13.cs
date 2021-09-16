using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_persona",
                table: "Usuarios",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IDPlan",
                table: "Personas",
                column: "IDPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_id_comision",
                table: "Cursos",
                column: "id_comision");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_id_materia",
                table: "Cursos",
                column: "id_materia");

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_id_plan",
                table: "Comisiones",
                column: "id_plan");

            migrationBuilder.AddForeignKey(
                name: "FK_Comisiones_Planes_id_plan",
                table: "Comisiones",
                column: "id_plan",
                principalTable: "Planes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Planes_IDPlan",
                table: "Personas",
                column: "IDPlan",
                principalTable: "Planes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Personas_id_persona",
                table: "Usuarios",
                column: "id_persona",
                principalTable: "Personas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comisiones_Planes_id_plan",
                table: "Comisiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Comisiones_id_comision",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Materias_id_materia",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Planes_IDPlan",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Personas_id_persona",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_id_persona",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IDPlan",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_id_comision",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_id_materia",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Comisiones_id_plan",
                table: "Comisiones");
        }
    }
}
