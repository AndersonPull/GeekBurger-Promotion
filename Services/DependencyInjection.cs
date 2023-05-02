using System;
using Services.ServiceBus;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public  class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IServiceBus, Services.ServiceBus.Implementation.ServiceBus>();
        }
    }
}

