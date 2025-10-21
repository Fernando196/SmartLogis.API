using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLogis.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    idEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(130)", maxLength: 130, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.idEstatus);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEstatus = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rfc = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    pais = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    idCreationUser = table.Column<int>(type: "int", nullable: false),
                    creationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idModificationUser = table.Column<int>(type: "int", nullable: true),
                    modificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Estatus_idEstatus",
                        column: x => x.idEstatus,
                        principalTable: "Estatus",
                        principalColumn: "idEstatus");
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    IdRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRuta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DistanciaKm = table.Column<int>(type: "int", maxLength: 500, nullable: false),
                    TiempoEstimadoHoras = table.Column<int>(type: "int", nullable: false),
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.IdRuta);
                    table.ForeignKey(
                        name: "FK_Rutas_Estatus_IdEstatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "idEstatus");
                });

            migrationBuilder.CreateTable(
                name: "Transportista",
                columns: table => new
                {
                    idTransportista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstatus = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    tipoUnidad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    placas = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportista", x => x.idTransportista);
                    table.ForeignKey(
                        name: "FK_Transportista_Estatus_IdEstatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "idEstatus");
                });

            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    idBitacora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.idBitacora);
                    table.ForeignKey(
                        name: "FK_Bitacora_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envio",
                columns: table => new
                {
                    idEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEstatus = table.Column<int>(type: "int", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    numeroGuia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    origen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    destino = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    volumen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tipoEnvio = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    fechaSalida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fechaEntregaEstimada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    observaciones = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envio", x => x.idEnvio);
                    table.ForeignKey(
                        name: "FK_Envio_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_Envio_Cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                });

            migrationBuilder.CreateTable(
                name: "DetallesEnvio",
                columns: table => new
                {
                    idDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEnvio = table.Column<int>(type: "int", nullable: false),
                    idTransportista = table.Column<int>(type: "int", nullable: false),
                    idRuta = table.Column<int>(type: "int", nullable: false),
                    idEstatus = table.Column<int>(type: "int", nullable: false),
                    decripcionCarga = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnvioIdEnvio = table.Column<int>(type: "int", nullable: true),
                    RutasIdRuta = table.Column<int>(type: "int", nullable: true),
                    TransportistaIdTransportista = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesEnvio", x => x.idDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Envio_EnvioIdEnvio",
                        column: x => x.EnvioIdEnvio,
                        principalTable: "Envio",
                        principalColumn: "idEnvio");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Envio_idEnvio",
                        column: x => x.idEnvio,
                        principalTable: "Envio",
                        principalColumn: "idEnvio");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Estatus_idEstatus",
                        column: x => x.idEstatus,
                        principalTable: "Estatus",
                        principalColumn: "idEstatus");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Rutas_RutasIdRuta",
                        column: x => x.RutasIdRuta,
                        principalTable: "Rutas",
                        principalColumn: "IdRuta");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Rutas_idRuta",
                        column: x => x.idRuta,
                        principalTable: "Rutas",
                        principalColumn: "IdRuta");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Transportista_TransportistaIdTransportista",
                        column: x => x.TransportistaIdTransportista,
                        principalTable: "Transportista",
                        principalColumn: "idTransportista");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Transportista_idTransportista",
                        column: x => x.idTransportista,
                        principalTable: "Transportista",
                        principalColumn: "idTransportista");
                });

            migrationBuilder.CreateTable(
                name: "EstatusEnvio",
                columns: table => new
                {
                    idEstatusEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEnvio = table.Column<int>(type: "int", nullable: false),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    idEnvio1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusEnvio", x => x.idEstatusEnvio);
                    table.ForeignKey(
                        name: "FK_EstatusEnvio_Envio_idEnvio",
                        column: x => x.idEnvio,
                        principalTable: "Envio",
                        principalColumn: "idEnvio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_idUsuario",
                table: "Bitacora",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_idEstatus",
                table: "Cliente",
                column: "idEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_EnvioIdEnvio",
                table: "DetallesEnvio",
                column: "EnvioIdEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_idEnvio",
                table: "DetallesEnvio",
                column: "idEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_idEstatus",
                table: "DetallesEnvio",
                column: "idEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_idRuta",
                table: "DetallesEnvio",
                column: "idRuta");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_idTransportista",
                table: "DetallesEnvio",
                column: "idTransportista");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_RutasIdRuta",
                table: "DetallesEnvio",
                column: "RutasIdRuta");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_TransportistaIdTransportista",
                table: "DetallesEnvio",
                column: "TransportistaIdTransportista");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_ClienteIdCliente",
                table: "Envio",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Envio_idCliente",
                table: "Envio",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusEnvio_idEnvio",
                table: "EstatusEnvio",
                column: "idEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_IdEstatus",
                table: "Rutas",
                column: "IdEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Transportista_IdEstatus",
                table: "Transportista",
                column: "IdEstatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora");

            migrationBuilder.DropTable(
                name: "DetallesEnvio");

            migrationBuilder.DropTable(
                name: "EstatusEnvio");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Rutas");

            migrationBuilder.DropTable(
                name: "Transportista");

            migrationBuilder.DropTable(
                name: "Envio");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
