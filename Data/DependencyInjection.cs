using System;
using Data.SQLServer;
using Data.SQLServer.Promotion;
using Data.SQLServer.Promotion.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DependencyInjection
	{
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPromotionRepository, PromotionRepository>();
        }
    }
}