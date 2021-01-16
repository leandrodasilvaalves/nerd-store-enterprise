using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class HomeController : Controller
    {  
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();
            modelErro.ErroCode = id;
            
            if(id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
            }
            else if(id == 404)
            {
                modelErro.Mensagem = "A págin  que está procurando não existe! <br/> Em caso de dúvidas entre em contato com nosso suporte.";
                modelErro.Titulo = "Ops! Págin não encontrada.";
            }
            else if(id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão par fazer isto.";
                modelErro.Titulo = "Acesso Negado";
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelErro);
        }
    }
}
