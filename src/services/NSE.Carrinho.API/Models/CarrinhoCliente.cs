﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Carrinho.API.Models
{
    public class CarrinhoCliente
    {
        public readonly static int MAX_QUANTIDADE_ITEM = 5;

        public CarrinhoCliente() { Itens = new List<CarrinhoItem>(); }

        public CarrinhoCliente(Guid clienteId) : this()
        {
            Id = Guid.NewGuid();
            ClienteId = clienteId;
        }
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<CarrinhoItem> Itens { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public Voucher Voucher { get; set; }

        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUtilizado = true;
            CalcularValorCarrinho();
        }
        internal void CalcularValorCarrinho()
        {
            ValorTotal = Itens.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        private void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if (Voucher.TipoDesconto == TipoDescontoVoucher.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }

        internal bool CarrinhoItemExistente(CarrinhoItem item)
        {
            return Itens is not null && Itens.Any(p => p.ProdutoId == item.ProdutoId);
        }

        internal CarrinhoItem ObterPorProdutoId(Guid produtoId)
        {
            return Itens.FirstOrDefault(p => p.ProdutoId == produtoId);
        }

        internal void AdicionarItem(CarrinhoItem item)
        {
            item.AssociarCarrinho(Id);
            if (CarrinhoItemExistente(item))
            {
                var itemExistente = ObterPorProdutoId(item.ProdutoId);
                itemExistente.AdicionarUnidades(item.Quantidade);
                item = itemExistente;
                Itens.Remove(itemExistente);
            }
            Itens.Add(item);
            CalcularValorCarrinho();
        }

        internal void AtualizarItem(CarrinhoItem item)
        {
            item.AssociarCarrinho(Id);
            var itemExistente = ObterPorProdutoId(item.ProdutoId);
            Itens.Remove(itemExistente);
            Itens.Add(item);
            CalcularValorCarrinho();
        }

        internal void AtualizarUnidades(CarrinhoItem item, int unidades)
        {
            item.AtualizarUnidades(unidades);
            AtualizarItem(item);
        }

        internal void RemoverItem(CarrinhoItem item)
        {
            Itens.Remove(ObterPorProdutoId(item.ProdutoId));
            CalcularValorCarrinho();
        }

        public bool EhValido()
        {
            var erros = Itens.SelectMany(i => new ItemCarrinhoValidation().Validate(i).Errors).ToList();
            erros.AddRange(new CarrinhoClienteValidtion().Validate(this).Errors);
            ValidationResult = new ValidationResult(erros);
            return ValidationResult.IsValid;
        }
    }

    public class CarrinhoClienteValidtion : AbstractValidator<CarrinhoCliente>
    {
        public CarrinhoClienteValidtion()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Cliente não reconhecido");

            RuleFor(c => c.Itens.Count)
                .GreaterThan(0)
                .WithMessage("O carrinho não possui itens");

            RuleFor(c => c.ValorTotal)
                .GreaterThan(0)
                .WithMessage("O valor total do carrinho precisa maior que 0");
        }
    }
}
