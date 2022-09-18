using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarEnergy.Api.Data.Migrations
{
    public partial class Terceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Unidades",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "Unidades",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Unidades",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Unidades",
                newName: "Apelido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Unidades",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Unidades",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Unidades",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "Apelido",
                table: "Unidades",
                newName: "Brand");
        }
    }
}
