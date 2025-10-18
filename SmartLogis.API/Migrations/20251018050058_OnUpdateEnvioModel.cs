using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLogis.API.Migrations
{
    /// <inheritdoc />
    public partial class OnUpdateEnvioModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstatusEnvio_Envio_idEnvio1",
                table: "EstatusEnvio");

            migrationBuilder.DropIndex(
                name: "IX_EstatusEnvio_idEnvio1",
                table: "EstatusEnvio");

            migrationBuilder.RenameColumn(
                name: "idEstatusEnvio",
                table: "Envio",
                newName: "idEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusEnvio_idEnvio",
                table: "EstatusEnvio",
                column: "idEnvio");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatusEnvio_Envio_idEnvio",
                table: "EstatusEnvio",
                column: "idEnvio",
                principalTable: "Envio",
                principalColumn: "idEnvio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstatusEnvio_Envio_idEnvio",
                table: "EstatusEnvio");

            migrationBuilder.DropIndex(
                name: "IX_EstatusEnvio_idEnvio",
                table: "EstatusEnvio");

            migrationBuilder.RenameColumn(
                name: "idEstatus",
                table: "Envio",
                newName: "idEstatusEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusEnvio_idEnvio1",
                table: "EstatusEnvio",
                column: "idEnvio1");

            migrationBuilder.AddForeignKey(
                name: "FK_EstatusEnvio_Envio_idEnvio1",
                table: "EstatusEnvio",
                column: "idEnvio1",
                principalTable: "Envio",
                principalColumn: "idEnvio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
