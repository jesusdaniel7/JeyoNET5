using Microsoft.EntityFrameworkCore.Migrations;

namespace JeyoNET5.Data.Migrations
{
    public partial class updating_ingreso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CentroProcedencia",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CondicionEspecial",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CondicionLlegada",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Oficio",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preeindicaciones",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelacionPaciente",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoAlterno",
                table: "Ingresos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CentroProcedencia",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "CondicionEspecial",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "CondicionLlegada",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "Oficio",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "Preeindicaciones",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "RelacionPaciente",
                table: "Ingresos");

            migrationBuilder.DropColumn(
                name: "TelefonoAlterno",
                table: "Ingresos");
        }
    }
}
