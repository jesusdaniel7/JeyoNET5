using Microsoft.EntityFrameworkCore.Migrations;

namespace JeyoNET5.Data.Migrations
{
    public partial class updating_factura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Pacientes_PacienteID",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_PacienteID",
                table: "Facturas");

            migrationBuilder.RenameColumn(
                name: "PacienteID",
                table: "Facturas",
                newName: "IngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IngresoId",
                table: "Facturas",
                column: "IngresoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Ingresos_IngresoId",
                table: "Facturas",
                column: "IngresoId",
                principalTable: "Ingresos",
                principalColumn: "IngresoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Ingresos_IngresoId",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_IngresoId",
                table: "Facturas");

            migrationBuilder.RenameColumn(
                name: "IngresoId",
                table: "Facturas",
                newName: "PacienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_PacienteID",
                table: "Facturas",
                column: "PacienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Pacientes_PacienteID",
                table: "Facturas",
                column: "PacienteID",
                principalTable: "Pacientes",
                principalColumn: "PacienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
