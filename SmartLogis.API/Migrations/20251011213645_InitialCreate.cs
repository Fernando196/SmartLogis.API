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
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.IdEstatus);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCreationUser = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdModificationUser = table.Column<int>(type: "int", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Estatus_IdEstatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus");
                });

            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    IdRuta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoRuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanciaKm = table.Column<int>(type: "int", nullable: false),
                    TiempoEstimadoHoras = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.IdRuta);
                    table.ForeignKey(
                        name: "FK_Rutas_Estatus_IdEstatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus");
                });

            migrationBuilder.CreateTable(
                name: "Transportista",
                columns: table => new
                {
                    IdTransportista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUnidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportista", x => x.IdTransportista);
                    table.ForeignKey(
                        name: "FK_Transportista_Estatus_IdEstatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus");
                });

            migrationBuilder.CreateTable(
                name: "Bitacora",
                columns: table => new
                {
                    IdBitacora = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora", x => x.IdBitacora);
                    table.ForeignKey(
                        name: "FK_Bitacora_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Envio",
                columns: table => new
                {
                    IdEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroGuia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volumen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoEnvio = table.Column<int>(type: "int", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntregaEstimada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdEstatus = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envio", x => x.IdEnvio);
                    table.ForeignKey(
                        name: "FK_Envio_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Envio_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateTable(
                name: "DetallesEnvio",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEnvio = table.Column<int>(type: "int", nullable: false),
                    IdTransportista = table.Column<int>(type: "int", nullable: false),
                    IdRuta = table.Column<int>(type: "int", nullable: false),
                    IdEstatus = table.Column<int>(type: "int", nullable: false),
                    DescripcionCarga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EnvioIdEnvio = table.Column<int>(type: "int", nullable: true),
                    RutasIdRuta = table.Column<int>(type: "int", nullable: true),
                    TransportistaIdTransportista = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesEnvio", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Envio_EnvioIdEnvio",
                        column: x => x.EnvioIdEnvio,
                        principalTable: "Envio",
                        principalColumn: "IdEnvio");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Envio_IdEnvio",
                        column: x => x.IdEnvio,
                        principalTable: "Envio",
                        principalColumn: "IdEnvio");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Estatus_IdEstatus",
                        column: x => x.IdEstatus,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatus");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Rutas_IdRuta",
                        column: x => x.IdRuta,
                        principalTable: "Rutas",
                        principalColumn: "IdRuta");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Rutas_RutasIdRuta",
                        column: x => x.RutasIdRuta,
                        principalTable: "Rutas",
                        principalColumn: "IdRuta");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Transportista_IdTransportista",
                        column: x => x.IdTransportista,
                        principalTable: "Transportista",
                        principalColumn: "IdTransportista");
                    table.ForeignKey(
                        name: "FK_DetallesEnvio_Transportista_TransportistaIdTransportista",
                        column: x => x.TransportistaIdTransportista,
                        principalTable: "Transportista",
                        principalColumn: "IdTransportista");
                });

            migrationBuilder.CreateTable(
                name: "EstatusEnvio",
                columns: table => new
                {
                    IdEstatusEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEnvio = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusEnvio", x => x.IdEstatusEnvio);
                    table.ForeignKey(
                        name: "FK_EstatusEnvio_Envio_IdEnvio",
                        column: x => x.IdEnvio,
                        principalTable: "Envio",
                        principalColumn: "IdEnvio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_IdUsuario",
                table: "Bitacora",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdEstatus",
                table: "Cliente",
                column: "IdEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_EnvioIdEnvio",
                table: "DetallesEnvio",
                column: "EnvioIdEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_IdEnvio",
                table: "DetallesEnvio",
                column: "IdEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_IdEstatus",
                table: "DetallesEnvio",
                column: "IdEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_IdRuta",
                table: "DetallesEnvio",
                column: "IdRuta");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEnvio_IdTransportista",
                table: "DetallesEnvio",
                column: "IdTransportista");

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
                name: "IX_Envio_IdCliente",
                table: "Envio",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusEnvio_IdEnvio",
                table: "EstatusEnvio",
                column: "IdEnvio");

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
