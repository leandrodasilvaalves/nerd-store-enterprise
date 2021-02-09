using NSE.Pagamentos.API.Models;
using System.Threading.Tasks;

namespace NSE.Pagamentos.API.Facade
{
    public interface IPagamentoFacade
    {
        Task<Transacao> AutorizarPagamento(Pagamento pagamento);
    }
}
