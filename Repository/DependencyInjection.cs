using Repository.SQLServer;
using Repository.SQLServer.Promotion;
using Repository.SQLServer.Promotion.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
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