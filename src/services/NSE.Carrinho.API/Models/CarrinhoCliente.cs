using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Carrinho.API.Models
{
    public class CarrinhoCliente
    {
        public CarrinhoCliente() { }

        public CarrinhoCliente(Guid clienteId)
        {
            Id = Guid.NewGuid();
            ClienteId = clienteId;
        }
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }
        public decimal ValorTodal { get; set; }
        public List<CarrinhoItem> Itens { get; set; }
        
    }
}
