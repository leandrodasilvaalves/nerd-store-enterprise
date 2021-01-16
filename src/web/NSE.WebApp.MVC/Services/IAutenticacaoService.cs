using NSE.WebApp.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        Task<string> Login(UsuarioLogin usuarioLogin);

        Task<string> Registro(UsuarioRegistro usuarioRegistro);
    }
}
