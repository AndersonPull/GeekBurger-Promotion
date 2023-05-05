using System;
using System.Data;
using Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.SQLServer.Promotion.Implementation
{
	public class PromotionRepository : GenericRepository<PromotionEntity>, IPromotionRepository
    {
        public PromotionRepository(RepositoryContext context) : base(context) { }

        public List<PromotionEntity> FindByStoreName(string storeName)
            => _context.Promotion.Where(promotion => promotion.StoreName.Equals(storeName)).ToList();
    }
}

