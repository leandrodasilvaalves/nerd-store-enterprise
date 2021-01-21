using FluentValidation.Results;
using MediatR;
using NSE.Clientes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, 
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
                return message.ValidationResult;


            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);
            //validacoes de  negocio
            //persistir no banco

            if(true) //já existe cliente com o CPF informado
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}
