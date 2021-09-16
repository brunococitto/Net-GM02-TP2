using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Planes_id_especialidad",
                table: "Planes",
                column: "id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_id_plan",
                table: "Materias",
                column: "id_plan");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Planes_id_plan",
                table: "Materias",
                column: "id_plan",
                principalTable: "Planes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Especialidades_id_especialidad",
                table: "Planes",
                column: "id_especialidad",
                principalTable: "Especialidades",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Planes_id_plan",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Especialidades_id_especialidad",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_id_especialidad",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Materias_id_plan",
                table: "Materias");
        }
    }
}
