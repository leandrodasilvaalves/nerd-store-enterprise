using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var respone = await _httpClient.GetAsync($"/catalogo/produtos/{id}");
            TratarErrosResponse(respone);
            return await DeserializarObjetoResponse<ProdutoViewModel>(respone);
        }

        public async Task<PagedViewModel<ProdutoViewModel>> ObterTodos(int pageSize, int pageIndex, string query = null)
        {
            var respone = await _httpClient.GetAsync($"/catalogo/produtos?ps={pageSize}&page={pageIndex}&q={query}");
            TratarErrosResponse(respone);
            return await DeserializarObjetoResponse<PagedViewModel<ProdutoViewModel>>(respone);
        }
    }
}
