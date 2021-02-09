//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NSE.Pagamentos.API.Configuration
//{
//    public static class MessageBusConfig
//    {
//        public static void AddMessageBusConfiguration(this IServiceCollection services,
//            IConfiguration configuration)
//        {
//            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
//                .AddHostedService<PagamentoIntegrationHandler>();
//        }
//    }
//}
