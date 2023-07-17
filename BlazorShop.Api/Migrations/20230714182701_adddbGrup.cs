using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class adddbGrup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GrupoUsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GrupoUsuario",
                columns: table => new
                {
                    IdGrupoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGrupoUsuario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuario", x => x.IdGrupoUsuario);
                });

            migrationBuilder.InsertData(
                table: "GrupoUsuario",
                columns: new[] { "IdGrupoUsuario", "NomeGrupoUsuario" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Gerente" },
                    { 3, "Cliente" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "GrupoUsuarioId", "Password" },
                values: new object[] { "ADM@ASFOOD.COM", 1, "AdmSenha" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_GrupoUsuarioId",
                table: "Usuarios",
                column: "GrupoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_GrupoUsuario_GrupoUsuarioId",
                table: "Usuarios",
                column: "GrupoUsuarioId",
                principalTable: "GrupoUsuario",
                principalColumn: "IdGrupoUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_GrupoUsuario_GrupoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "GrupoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_GrupoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "GrupoUsuarioId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: null);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "Contato", "NomeUsuario", "Password" },
                values: new object[] { 2, null, null, "Client", null });
        }
    }
}
