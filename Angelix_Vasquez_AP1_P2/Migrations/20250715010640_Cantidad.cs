using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Angelix_Vasquez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class Cantidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "EntradasDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductosId",
                keyValue: 1,
                column: "Peso",
                value: 12.0);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductosId",
                keyValue: 2,
                column: "Peso",
                value: 17.0);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductosId",
                keyValue: 3,
                column: "Peso",
                value: 3.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "EntradasDetalle");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductosId",
                keyValue: 1,
                column: "Peso",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductosId",
                keyValue: 2,
                column: "Peso",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductosId",
                keyValue: 3,
                column: "Peso",
                value: 0.0);
        }
    }
}
