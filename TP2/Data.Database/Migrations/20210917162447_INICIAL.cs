using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Database.Migrations
{
    public partial class INICIAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc_especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc_modulo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModulosUsuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdModulo = table.Column<int>(type: "int", nullable: false),
                    PermiteAlta = table.Column<bool>(type: "bit", nullable: false),
                    PermiteBaja = table.Column<bool>(type: "bit", nullable: false),
                    PermiteConsulta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosUsuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc_plan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_especialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Planes_Especialidades_id_especialidad",
                        column: x => x.id_especialidad,
                        principalTable: "Especialidades",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Comisiones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anio_especialidad = table.Column<int>(type: "int", nullable: false),
                    desc_comision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_plan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comisiones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comisiones_Planes_id_plan",
                        column: x => x.id_plan,
                        principalTable: "Planes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc_materia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hs_semanales = table.Column<int>(type: "int", nullable: false),
                    hs_totales = table.Column<int>(type: "int", nullable: false),
                    id_plan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materias_Planes_id_plan",
                        column: x => x.id_plan,
                        principalTable: "Planes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDPlan = table.Column<int>(type: "int", nullable: true),
                    Legajo = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Personas_Planes_IDPlan",
                        column: x => x.IDPlan,
                        principalTable: "Planes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anio_calendario = table.Column<int>(type: "int", nullable: false),
                    cupo = table.Column<int>(type: "int", nullable: false),
                    desc_curso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_comision = table.Column<int>(type: "int", nullable: false),
                    id_materia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cursos_Comisiones_id_comision",
                        column: x => x.id_comision,
                        principalTable: "Comisiones",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Cursos_Materias_id_materia",
                        column: x => x.id_materia,
                        principalTable: "Materias",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    habilitado = table.Column<bool>(type: "bit", nullable: false),
                    id_persona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_id_persona",
                        column: x => x.id_persona,
                        principalTable: "Personas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AlumnoInscripciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDAlumno = table.Column<int>(type: "int", nullable: false),
                    IDCurso = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoInscripciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlumnoInscripciones_Cursos_IDCurso",
                        column: x => x.IDCurso,
                        principalTable: "Cursos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_AlumnoInscripciones_Personas_IDAlumno",
                        column: x => x.IDAlumno,
                        principalTable: "Personas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DocentesCursos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    IDCurso = table.Column<int>(type: "int", nullable: false),
                    IDDocente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocentesCursos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DocentesCursos_Cursos_IDCurso",
                        column: x => x.IDCurso,
                        principalTable: "Cursos",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DocentesCursos_Personas_IDDocente",
                        column: x => x.IDDocente,
                        principalTable: "Personas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoInscripciones_IDAlumno",
                table: "AlumnoInscripciones",
                column: "IDAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoInscripciones_IDCurso",
                table: "AlumnoInscripciones",
                column: "IDCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Comisiones_id_plan",
                table: "Comisiones",
                column: "id_plan");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_id_comision",
                table: "Cursos",
                column: "id_comision");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_id_materia",
                table: "Cursos",
                column: "id_materia");

            migrationBuilder.CreateIndex(
                name: "IX_DocentesCursos_IDCurso",
                table: "DocentesCursos",
                column: "IDCurso");

            migrationBuilder.CreateIndex(
                name: "IX_DocentesCursos_IDDocente",
                table: "DocentesCursos",
                column: "IDDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_id_plan",
                table: "Materias",
                column: "id_plan");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IDPlan",
                table: "Personas",
                column: "IDPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_id_especialidad",
                table: "Planes",
                column: "id_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_id_persona",
                table: "Usuarios",
                column: "id_persona");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoInscripciones");

            migrationBuilder.DropTable(
                name: "DocentesCursos");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "ModulosUsuarios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Comisiones");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
