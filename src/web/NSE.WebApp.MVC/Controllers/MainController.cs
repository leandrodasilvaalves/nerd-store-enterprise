using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using System.Linq;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                foreach(var mensgem in resposta.Errors.Mensagens)
                    ModelState.AddModelError(string.Empty, mensgem);

                return true;
            }

            return false;
        }
    }
}
