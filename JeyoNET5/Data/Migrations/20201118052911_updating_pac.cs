using Microsoft.EntityFrameworkCore.Migrations;

namespace JeyoNET5.Data.Migrations
{
    public partial class updating_pac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apelido",
                table: "Pacientes",
                newName: "Parentesco");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cedula_pasaporte",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Cedula_pasaporte",
                table: "Pacientes");

            migrationBuilder.RenameColumn(
                name: "Parentesco",
                table: "Pacientes",
                newName: "Apelido");
        }
    }
}
