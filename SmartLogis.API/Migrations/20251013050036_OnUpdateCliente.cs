using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLogis.API.Migrations
{
    /// <inheritdoc />
    public partial class OnUpdateCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Cliente",
                newName: "idCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Cliente",
                newName: "idUsuario");
        }
    }
}
