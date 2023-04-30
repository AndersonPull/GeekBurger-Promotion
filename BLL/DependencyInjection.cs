using System;
using BLL.Promotion;
using BLL.Promotion.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPromotionBLL, PromotionBLL>();
        }
    }
}

