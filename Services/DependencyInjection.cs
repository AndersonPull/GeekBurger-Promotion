using System;
using Services.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Services.Produtos;
using Services.Produtos.Implementation;

namespace Services
{
    public  class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IServiceBus, ServiceBus.Implementation.ServiceBus>();
        }
    }
}