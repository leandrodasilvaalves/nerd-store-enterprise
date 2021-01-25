using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Carrinho.API.Migrations
{
    public partial class Corrigir_Campo_Nome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorTodal",
                table: "CarrinhoCliente",
                newName: "ValorTotal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorTotal",
                table: "CarrinhoCliente",
                newName: "ValorTodal");
        }
    }
}
