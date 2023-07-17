using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class Pedidos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoIdPedido",
                table: "CarrinhoItens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TotalPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusPedido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_PedidoIdPedido",
                table: "CarrinhoItens",
                column: "PedidoIdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_Pedidos_PedidoIdPedido",
                table: "CarrinhoItens",
                column: "PedidoIdPedido",
                principalTable: "Pedidos",
                principalColumn: "IdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_Pedidos_PedidoIdPedido",
                table: "CarrinhoItens");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoItens_PedidoIdPedido",
                table: "CarrinhoItens");

            migrationBuilder.DropColumn(
                name: "PedidoIdPedido",
                table: "CarrinhoItens");
        }
    }
}
