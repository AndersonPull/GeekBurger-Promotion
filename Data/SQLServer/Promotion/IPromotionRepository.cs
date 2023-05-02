using System;
using Data.Model;

namespace Data.SQLServer.Promotion
{
	public interface IPromotionRepository : IRepository<PromotionEntity>
    {
        PromotionEntity FindByStoreName(string storeName);
    }
}