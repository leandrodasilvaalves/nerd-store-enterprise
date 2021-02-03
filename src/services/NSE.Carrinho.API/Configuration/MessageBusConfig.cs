using Microsoft.Extensions.DependencyInjection;
using NSE.Carrinho.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSE.MessageBus;
using NSE.Core.Utils;
using Microsoft.Extensions.Configuration;

namespace NSE.Carrinho.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<CarrinhoIntegrationHandler>();
        }
    }
}
