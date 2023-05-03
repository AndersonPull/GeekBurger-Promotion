using System;
using AutoMapper;
using Contracts.Models;
using Contracts.Models.Request;
using Contracts.Models.Response;
using Repository.Model;

namespace BLL.Mapper
{
	public static class AccessMapper
	{
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PromotionEntity, PromotionResponse>();
                cfg.CreateMap<PromotionRequest, PromotionEntity>();
            });
            return mapperConfiguration.CreateMapper();
        }

    }
}

