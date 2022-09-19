using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarEnergy.Api.Data.Migrations
{
    public partial class Sexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gerações_Unidades_UnidadeId",
                table: "Gerações");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gerações",
                table: "Gerações");

            migrationBuilder.RenameTable(
                name: "Gerações",
                newName: "Geracoes");

            migrationBuilder.RenameIndex(
                name: "IX_Gerações_UnidadeId",
                table: "Geracoes",
                newName: "IX_Geracoes_UnidadeId");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Unidades",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Unidades",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Unidades",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Apelido",
                table: "Unidades",
                type: "VARCHAR(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Geracoes",
                table: "Geracoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Geracoes_Unidades_UnidadeId",
                table: "Geracoes",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Geracoes_Unidades_UnidadeId",
                table: "Geracoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Geracoes",
                table: "Geracoes");

            migrationBuilder.RenameTable(
                name: "Geracoes",
                newName: "Gerações");

            migrationBuilder.RenameIndex(
                name: "IX_Geracoes_UnidadeId",
                table: "Gerações",
                newName: "IX_Gerações_UnidadeId");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Unidades",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                table: "Unidades",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Unidades",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Apelido",
                table: "Unidades",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gerações",
                table: "Gerações",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gerações_Unidades_UnidadeId",
                table: "Gerações",
                column: "UnidadeId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
