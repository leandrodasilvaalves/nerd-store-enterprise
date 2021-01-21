﻿using Microsoft.EntityFrameworkCore;
using NSE.Clientes.API.Models;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;

        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public async Task<Cliente> ObterPorCpf(string cpf)
        {
            return _context.Clientes.AsNoTracking().FirstOrDefault(c => c.Cpf.Numero == cpf);
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
