using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Especialidades",
                newName: "desc_especialidad");

            migrationBuilder.RenameColumn(
                name: "IDPlan",
                table: "Comisiones",
                newName: "id_plan");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Comisiones",
                newName: "desc_comision");

            migrationBuilder.RenameColumn(
                name: "AnoEspecialidad",
                table: "Comisiones",
                newName: "anio_especialidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "desc_especialidad",
                table: "Especialidades",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "id_plan",
                table: "Comisiones",
                newName: "IDPlan");

            migrationBuilder.RenameColumn(
                name: "desc_comision",
                table: "Comisiones",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "anio_especialidad",
                table: "Comisiones",
                newName: "AnoEspecialidad");
        }
    }
}
