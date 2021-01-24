using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Carrinho.API.Migrations
{
    public partial class Corrigir_Campo_ProdutoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "guid",
                table: "CarrinhoItens",
                newName: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "CarrinhoItens",
                newName: "guid");
        }
    }
}
