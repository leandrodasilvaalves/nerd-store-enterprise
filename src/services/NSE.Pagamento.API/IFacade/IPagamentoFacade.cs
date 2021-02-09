using NSE.Pagamentos.API.Models;
using System.Threading.Tasks;

namespace NSE.Pagamentos.API.IFacade
{
    public interface IPagamentoFacade
    {
        Task<Transacao> AutorizarPagamento(Pagamento pagamento);
    }
}
