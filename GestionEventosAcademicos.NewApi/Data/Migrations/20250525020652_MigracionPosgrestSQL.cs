using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionEventosAcademicos.NewApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPosgrestSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Idevento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Lugar = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Idevento);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Idparticipante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Cedula = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Idparticipante);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    Idponente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Idponente);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Idactividad = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Idevento = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Fechainicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fechafin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Sala = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Idactividad);
                    table.ForeignKey(
                        name: "FK_Actividades_Eventos_Idevento",
                        column: x => x.Idevento,
                        principalTable: "Eventos",
                        principalColumn: "Idevento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Idinscripcion = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Idevento = table.Column<int>(type: "integer", nullable: false),
                    Idparticipante = table.Column<int>(type: "integer", nullable: false),
                    Fechainscripcion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstadoInscripcion = table.Column<string>(type: "text", nullable: false),
                    Fechapago = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Mediopago = table.Column<string>(type: "text", nullable: false),
                    EstadoPago = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Idinscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_Idevento",
                        column: x => x.Idevento,
                        principalTable: "Eventos",
                        principalColumn: "Idevento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_Idparticipante",
                        column: x => x.Idparticipante,
                        principalTable: "Participantes",
                        principalColumn: "Idparticipante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventoponentes",
                columns: table => new
                {
                    Idevento = table.Column<int>(type: "integer", nullable: false),
                    Idponente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventoponentes", x => new { x.Idevento, x.Idponente });
                    table.ForeignKey(
                        name: "FK_Eventoponentes_Eventos_Idevento",
                        column: x => x.Idevento,
                        principalTable: "Eventos",
                        principalColumn: "Idevento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventoponentes_Ponentes_Idponente",
                        column: x => x.Idponente,
                        principalTable: "Ponentes",
                        principalColumn: "Idponente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    Idasistencia = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Idinscripcion = table.Column<int>(type: "integer", nullable: false),
                    Idactividad = table.Column<int>(type: "integer", nullable: false),
                    Asistio = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.Idasistencia);
                    table.ForeignKey(
                        name: "FK_Asistencias_Actividades_Idactividad",
                        column: x => x.Idactividad,
                        principalTable: "Actividades",
                        principalColumn: "Idactividad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Inscripciones_Idinscripcion",
                        column: x => x.Idinscripcion,
                        principalTable: "Inscripciones",
                        principalColumn: "Idinscripcion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Idcertificado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Idinscripcion = table.Column<int>(type: "integer", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstadoCertificado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Idcertificado);
                    table.ForeignKey(
                        name: "FK_Certificados_Inscripciones_Idinscripcion",
                        column: x => x.Idinscripcion,
                        principalTable: "Inscripciones",
                        principalColumn: "Idinscripcion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_Idevento",
                table: "Actividades",
                column: "Idevento");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_Idactividad",
                table: "Asistencias",
                column: "Idactividad");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_Idinscripcion",
                table: "Asistencias",
                column: "Idinscripcion");

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_Idinscripcion",
                table: "Certificados",
                column: "Idinscripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventoponentes_Idponente",
                table: "Eventoponentes",
                column: "Idponente");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_Idevento",
                table: "Inscripciones",
                column: "Idevento");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_Idparticipante",
                table: "Inscripciones",
                column: "Idparticipante");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_Correo",
                table: "Participantes",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ponentes_Correo",
                table: "Ponentes",
                column: "Correo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "Eventoponentes");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
