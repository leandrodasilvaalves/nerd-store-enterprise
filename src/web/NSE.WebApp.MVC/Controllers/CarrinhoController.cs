using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    [Route("carrinho")]
    public class CarrinhoController : MainController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Route("adicionar-item")]
        public async Task<IActionResult> AdicionarItemCarrinho(ItemProdutoViewModel itemProduto)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("atualizar-item")]
        public async Task<IActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("remover-item")]
        public async Task<IActionResult> RemoverItemCarrinho(Guid produtoId, int quantidade)
        {
            return RedirectToAction("Index");
        }
    }
}
