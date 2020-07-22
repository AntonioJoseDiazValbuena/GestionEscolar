using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionEscolar.Datos.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    TarjetaIdentidad = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.TarjetaIdentidad);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CedulaProfesor = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IdMateria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Profesores_CedulaProfesor",
                        column: x => x.CedulaProfesor,
                        principalTable: "Profesores",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupos_Materias_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriasEstudiantes",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(nullable: false),
                    TarjetaIdentidadEstudiante = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    CalificacionPrimerPeriodo = table.Column<float>(nullable: true),
                    CalificacionSegundoPeriodo = table.Column<float>(nullable: true),
                    CalificacionTercerPeriodo = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasEstudiantes", x => new { x.IdGrupo, x.TarjetaIdentidadEstudiante });
                    table.ForeignKey(
                        name: "FK_MateriasEstudiantes_Grupos_IdGrupo",
                        column: x => x.IdGrupo,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriasEstudiantes_Estudiantes_TarjetaIdentidadEstudiante",
                        column: x => x.TarjetaIdentidadEstudiante,
                        principalTable: "Estudiantes",
                        principalColumn: "TarjetaIdentidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_IdMateria",
                table: "Grupos",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_CedulaProfesor_IdMateria",
                table: "Grupos",
                columns: new[] { "CedulaProfesor", "IdMateria" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MateriasEstudiantes_TarjetaIdentidadEstudiante",
                table: "MateriasEstudiantes",
                column: "TarjetaIdentidadEstudiante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriasEstudiantes");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
