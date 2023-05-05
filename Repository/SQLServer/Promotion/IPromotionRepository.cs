using System;
using Repository.Model;

namespace Repository.SQLServer.Promotion
{
	public interface IPromotionRepository : IRepository<PromotionEntity>
    {
        List<PromotionEntity> FindByStoreName(string storeName);
    }
}