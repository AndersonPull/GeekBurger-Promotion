using System;
using Services.ServiceBus;
using Services.ServiceBus.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public  class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IServiceBus, ServiceBus>();
        }
    }
}

