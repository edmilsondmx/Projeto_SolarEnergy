using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarEnergy.Infra.Migrations
{
    public partial class Oitava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "ROLE");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Users",
                newName: "NOME");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Unidades",
                newName: "MODELO");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Unidades",
                newName: "MARCA");

            migrationBuilder.RenameColumn(
                name: "Local",
                table: "Unidades",
                newName: "LOCAL");

            migrationBuilder.RenameColumn(
                name: "Apelido",
                table: "Unidades",
                newName: "APELIDO");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Unidades",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Kw",
                table: "Geracoes",
                newName: "KW");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Geracoes",
                newName: "DATA");

            migrationBuilder.AlterColumn<int>(
                name: "ROLE",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddColumn<byte[]>(
                name: "IMAGE",
                table: "Users",
                type: "VARBINARY(8000)",
                maxLength: 8000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMAGE",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ROLE",
                table: "Users",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "NOME",
                table: "Users",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "MODELO",
                table: "Unidades",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "MARCA",
                table: "Unidades",
                newName: "Marca");

            migrationBuilder.RenameColumn(
                name: "LOCAL",
                table: "Unidades",
                newName: "Local");

            migrationBuilder.RenameColumn(
                name: "APELIDO",
                table: "Unidades",
                newName: "Apelido");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "Unidades",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "KW",
                table: "Geracoes",
                newName: "Kw");

            migrationBuilder.RenameColumn(
                name: "DATA",
                table: "Geracoes",
                newName: "Data");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);
        }
    }
}
