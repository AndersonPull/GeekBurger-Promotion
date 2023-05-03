using System;
using AutoMapper;
using Contracts.Models;
using Repository.Model;

namespace BLL.Mapper
{
	public static class AccessMapper
	{
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PromotionEntity, PromotionModel>().ReverseMap(); ;

            });
            return mapperConfiguration.CreateMapper();
        }

    }
}

