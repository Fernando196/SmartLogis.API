using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLogis.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitacora_Usuario_IdUsuario",
                table: "Bitacora");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Estatus_IdEstatus",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Envio_IdEnvio",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Estatus_IdEstatus",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Rutas_IdRuta",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Transportista_IdTransportista",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Cliente_IdCliente",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_EstatusEnvio_Envio_IdEnvio",
                table: "EstatusEnvio");

            migrationBuilder.DropIndex(
                name: "IX_EstatusEnvio_IdEnvio",
                table: "EstatusEnvio");

            migrationBuilder.RenameColumn(
                name: "Rol",
                table: "Usuario",
                newName: "rol");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuario",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuario",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuario",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Usuario",
                newName: "creationDate");

            migrationBuilder.RenameColumn(
                name: "Activo",
                table: "Usuario",
                newName: "activo");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Usuario",
                newName: "idUsuario");

            migrationBuilder.RenameColumn(
                name: "TipoUnidad",
                table: "Transportista",
                newName: "tipoUnidad");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Transportista",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "Placas",
                table: "Transportista",
                newName: "placas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Transportista",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Transportista",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "IdTransportista",
                table: "Transportista",
                newName: "idTransportista");

            migrationBuilder.RenameColumn(
                name: "Ubicacion",
                table: "EstatusEnvio",
                newName: "ubicacion");

            migrationBuilder.RenameColumn(
                name: "IdEnvio",
                table: "EstatusEnvio",
                newName: "idEnvio");

            migrationBuilder.RenameColumn(
                name: "FechaHora",
                table: "EstatusEnvio",
                newName: "fechaHora");

            migrationBuilder.RenameColumn(
                name: "Comentario",
                table: "EstatusEnvio",
                newName: "comentario");

            migrationBuilder.RenameColumn(
                name: "IdEstatusEnvio",
                table: "EstatusEnvio",
                newName: "idEstatusEnvio");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Estatus",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "IdEstatus",
                table: "Estatus",
                newName: "idEstatus");

            migrationBuilder.RenameColumn(
                name: "Volumen",
                table: "Envio",
                newName: "volumen");

            migrationBuilder.RenameColumn(
                name: "TipoEnvio",
                table: "Envio",
                newName: "tipoEnvio");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Envio",
                newName: "peso");

            migrationBuilder.RenameColumn(
                name: "Origen",
                table: "Envio",
                newName: "origen");

            migrationBuilder.RenameColumn(
                name: "Observaciones",
                table: "Envio",
                newName: "observaciones");

            migrationBuilder.RenameColumn(
                name: "NumeroGuia",
                table: "Envio",
                newName: "numeroGuia");

            migrationBuilder.RenameColumn(
                name: "IdEstatus",
                table: "Envio",
                newName: "idEstatus");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Envio",
                newName: "idCliente");

            migrationBuilder.RenameColumn(
                name: "FechaSalida",
                table: "Envio",
                newName: "fechaSalida");

            migrationBuilder.RenameColumn(
                name: "FechaEntregaEstimada",
                table: "Envio",
                newName: "fechaEntregaEstimada");

            migrationBuilder.RenameColumn(
                name: "Destino",
                table: "Envio",
                newName: "destino");

            migrationBuilder.RenameColumn(
                name: "IdEnvio",
                table: "Envio",
                newName: "idEnvio");

            migrationBuilder.RenameIndex(
                name: "IX_Envio_IdCliente",
                table: "Envio",
                newName: "IX_Envio_idCliente");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "DetallesEnvio",
                newName: "peso");

            migrationBuilder.RenameColumn(
                name: "IdTransportista",
                table: "DetallesEnvio",
                newName: "idTransportista");

            migrationBuilder.RenameColumn(
                name: "IdRuta",
                table: "DetallesEnvio",
                newName: "idRuta");

            migrationBuilder.RenameColumn(
                name: "IdEstatus",
                table: "DetallesEnvio",
                newName: "idEstatus");

            migrationBuilder.RenameColumn(
                name: "IdEnvio",
                table: "DetallesEnvio",
                newName: "idEnvio");

            migrationBuilder.RenameColumn(
                name: "DescripcionCarga",
                table: "DetallesEnvio",
                newName: "descripcionCarga");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "DetallesEnvio",
                newName: "cantidad");

            migrationBuilder.RenameColumn(
                name: "IdDetalle",
                table: "DetallesEnvio",
                newName: "idDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_IdTransportista",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_idTransportista");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_IdRuta",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_idRuta");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_IdEstatus",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_idEstatus");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_IdEnvio",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_idEnvio");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Cliente",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "RFC",
                table: "Cliente",
                newName: "rfc");

            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "Cliente",
                newName: "pais");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Cliente",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "Cliente",
                newName: "modificationDate");

            migrationBuilder.RenameColumn(
                name: "IdModificationUser",
                table: "Cliente",
                newName: "idModificationUser");

            migrationBuilder.RenameColumn(
                name: "IdEstatus",
                table: "Cliente",
                newName: "idEstatus");

            migrationBuilder.RenameColumn(
                name: "IdCreationUser",
                table: "Cliente",
                newName: "idCreationUser");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Cliente",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Cliente",
                newName: "direccion");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Cliente",
                newName: "creationDate");

            migrationBuilder.RenameColumn(
                name: "Ciudad",
                table: "Cliente",
                newName: "ciudad");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Cliente",
                newName: "idUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_IdEstatus",
                table: "Cliente",
                newName: "IX_Cliente_idEstatus");

            migrationBuilder.RenameColumn(
                name: "Modulo",
                table: "Bitacora",
                newName: "modulo");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Bitacora",
                newName: "idUsuario");

            migrationBuilder.RenameColumn(
                name: "FechaHora",
                table: "Bitacora",
                newName: "fechaHora");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Bitacora",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "Accion",
                table: "Bitacora",
                newName: "accion");

            migrationBuilder.RenameColumn(
                name: "IdBitacora",
                table: "Bitacora",
                newName: "idBitacora");

            migrationBuilder.RenameIndex(
                name: "IX_Bitacora_IdUsuario",
                table: "Bitacora",
                newName: "IX_Bitacora_idUsuario");

            migrationBuilder.AddColumn<int>(
                name: "idEnvio1",
                table: "EstatusEnvio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EstatusEnvio_idEnvio1",
                table: "EstatusEnvio",
                column: "idEnvio1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bitacora_Usuario_idUsuario",
                table: "Bitacora",
                column: "idUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Estatus_idEstatus",
                table: "Cliente",
                column: "idEstatus",
                principalTable: "Estatus",
                principalColumn: "idEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Envio_idEnvio",
                table: "DetallesEnvio",
                column: "idEnvio",
                principalTable: "Envio",
                principalColumn: "idEnvio");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Estatus_idEstatus",
                table: "DetallesEnvio",
                column: "idEstatus",
                principalTable: "Estatus",
                principalColumn: "idEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Rutas_idRuta",
                table: "DetallesEnvio",
                column: "idRuta",
                principalTable: "Rutas",
                principalColumn: "IdRuta");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Transportista_idTransportista",
                table: "DetallesEnvio",
                column: "idTransportista",
                principalTable: "Transportista",
                principalColumn: "idTransportista");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Cliente_idCliente",
                table: "Envio",
                column: "idCliente",
                principalTable: "Cliente",
                principalColumn: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatusEnvio_Envio_idEnvio1",
                table: "EstatusEnvio",
                column: "idEnvio1",
                principalTable: "Envio",
                principalColumn: "idEnvio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bitacora_Usuario_idUsuario",
                table: "Bitacora");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Estatus_idEstatus",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Envio_idEnvio",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Estatus_idEstatus",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Rutas_idRuta",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvio_Transportista_idTransportista",
                table: "DetallesEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_Envio_Cliente_idCliente",
                table: "Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_EstatusEnvio_Envio_idEnvio1",
                table: "EstatusEnvio");

            migrationBuilder.DropIndex(
                name: "IX_EstatusEnvio_idEnvio1",
                table: "EstatusEnvio");

            migrationBuilder.DropColumn(
                name: "idEnvio1",
                table: "EstatusEnvio");

            migrationBuilder.RenameColumn(
                name: "rol",
                table: "Usuario",
                newName: "Rol");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Usuario",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Usuario",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "creationDate",
                table: "Usuario",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "activo",
                table: "Usuario",
                newName: "Activo");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Usuario",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "tipoUnidad",
                table: "Transportista",
                newName: "TipoUnidad");

            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Transportista",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "placas",
                table: "Transportista",
                newName: "Placas");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Transportista",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Transportista",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "idTransportista",
                table: "Transportista",
                newName: "IdTransportista");

            migrationBuilder.RenameColumn(
                name: "ubicacion",
                table: "EstatusEnvio",
                newName: "Ubicacion");

            migrationBuilder.RenameColumn(
                name: "idEnvio",
                table: "EstatusEnvio",
                newName: "IdEnvio");

            migrationBuilder.RenameColumn(
                name: "fechaHora",
                table: "EstatusEnvio",
                newName: "FechaHora");

            migrationBuilder.RenameColumn(
                name: "comentario",
                table: "EstatusEnvio",
                newName: "Comentario");

            migrationBuilder.RenameColumn(
                name: "idEstatusEnvio",
                table: "EstatusEnvio",
                newName: "IdEstatusEnvio");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Estatus",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "idEstatus",
                table: "Estatus",
                newName: "IdEstatus");

            migrationBuilder.RenameColumn(
                name: "volumen",
                table: "Envio",
                newName: "Volumen");

            migrationBuilder.RenameColumn(
                name: "tipoEnvio",
                table: "Envio",
                newName: "TipoEnvio");

            migrationBuilder.RenameColumn(
                name: "peso",
                table: "Envio",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "origen",
                table: "Envio",
                newName: "Origen");

            migrationBuilder.RenameColumn(
                name: "observaciones",
                table: "Envio",
                newName: "Observaciones");

            migrationBuilder.RenameColumn(
                name: "numeroGuia",
                table: "Envio",
                newName: "NumeroGuia");

            migrationBuilder.RenameColumn(
                name: "idEstatus",
                table: "Envio",
                newName: "IdEstatus");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Envio",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "fechaSalida",
                table: "Envio",
                newName: "FechaSalida");

            migrationBuilder.RenameColumn(
                name: "fechaEntregaEstimada",
                table: "Envio",
                newName: "FechaEntregaEstimada");

            migrationBuilder.RenameColumn(
                name: "destino",
                table: "Envio",
                newName: "Destino");

            migrationBuilder.RenameColumn(
                name: "idEnvio",
                table: "Envio",
                newName: "IdEnvio");

            migrationBuilder.RenameIndex(
                name: "IX_Envio_idCliente",
                table: "Envio",
                newName: "IX_Envio_IdCliente");

            migrationBuilder.RenameColumn(
                name: "peso",
                table: "DetallesEnvio",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "idTransportista",
                table: "DetallesEnvio",
                newName: "IdTransportista");

            migrationBuilder.RenameColumn(
                name: "idRuta",
                table: "DetallesEnvio",
                newName: "IdRuta");

            migrationBuilder.RenameColumn(
                name: "idEstatus",
                table: "DetallesEnvio",
                newName: "IdEstatus");

            migrationBuilder.RenameColumn(
                name: "idEnvio",
                table: "DetallesEnvio",
                newName: "IdEnvio");

            migrationBuilder.RenameColumn(
                name: "descripcionCarga",
                table: "DetallesEnvio",
                newName: "DescripcionCarga");

            migrationBuilder.RenameColumn(
                name: "cantidad",
                table: "DetallesEnvio",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "idDetalle",
                table: "DetallesEnvio",
                newName: "IdDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_idTransportista",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_IdTransportista");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_idRuta",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_IdRuta");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_idEstatus",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_IdEstatus");

            migrationBuilder.RenameIndex(
                name: "IX_DetallesEnvio_idEnvio",
                table: "DetallesEnvio",
                newName: "IX_DetallesEnvio_IdEnvio");

            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Cliente",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "rfc",
                table: "Cliente",
                newName: "RFC");

            migrationBuilder.RenameColumn(
                name: "pais",
                table: "Cliente",
                newName: "Pais");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Cliente",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "modificationDate",
                table: "Cliente",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "idModificationUser",
                table: "Cliente",
                newName: "IdModificationUser");

            migrationBuilder.RenameColumn(
                name: "idEstatus",
                table: "Cliente",
                newName: "IdEstatus");

            migrationBuilder.RenameColumn(
                name: "idCreationUser",
                table: "Cliente",
                newName: "IdCreationUser");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Cliente",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "direccion",
                table: "Cliente",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "creationDate",
                table: "Cliente",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "ciudad",
                table: "Cliente",
                newName: "Ciudad");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Cliente",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Cliente_idEstatus",
                table: "Cliente",
                newName: "IX_Cliente_IdEstatus");

            migrationBuilder.RenameColumn(
                name: "modulo",
                table: "Bitacora",
                newName: "Modulo");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Bitacora",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "fechaHora",
                table: "Bitacora",
                newName: "FechaHora");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "Bitacora",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "accion",
                table: "Bitacora",
                newName: "Accion");

            migrationBuilder.RenameColumn(
                name: "idBitacora",
                table: "Bitacora",
                newName: "IdBitacora");

            migrationBuilder.RenameIndex(
                name: "IX_Bitacora_idUsuario",
                table: "Bitacora",
                newName: "IX_Bitacora_IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusEnvio_IdEnvio",
                table: "EstatusEnvio",
                column: "IdEnvio");

            migrationBuilder.AddForeignKey(
                name: "FK_Bitacora_Usuario_IdUsuario",
                table: "Bitacora",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Estatus_IdEstatus",
                table: "Cliente",
                column: "IdEstatus",
                principalTable: "Estatus",
                principalColumn: "IdEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Envio_IdEnvio",
                table: "DetallesEnvio",
                column: "IdEnvio",
                principalTable: "Envio",
                principalColumn: "IdEnvio");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Estatus_IdEstatus",
                table: "DetallesEnvio",
                column: "IdEstatus",
                principalTable: "Estatus",
                principalColumn: "IdEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Rutas_IdRuta",
                table: "DetallesEnvio",
                column: "IdRuta",
                principalTable: "Rutas",
                principalColumn: "IdRuta");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvio_Transportista_IdTransportista",
                table: "DetallesEnvio",
                column: "IdTransportista",
                principalTable: "Transportista",
                principalColumn: "IdTransportista");

            migrationBuilder.AddForeignKey(
                name: "FK_Envio_Cliente_IdCliente",
                table: "Envio",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatusEnvio_Envio_IdEnvio",
                table: "EstatusEnvio",
                column: "IdEnvio",
                principalTable: "Envio",
                principalColumn: "IdEnvio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
