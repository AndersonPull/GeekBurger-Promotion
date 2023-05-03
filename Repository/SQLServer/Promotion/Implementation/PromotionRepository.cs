using System;
using System.Data;
using Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.SQLServer.Promotion.Implementation
{
	public class PromotionRepository : GenericRepository<PromotionEntity>, IPromotionRepository
    {
        public PromotionRepository(RepositoryContext context) : base(context) { }

        public PromotionEntity FindByStoreName(string storeName)
            => _context.Promotion.SingleOrDefault(promotion => promotion.StoreName.Equals(storeName));
    }
}

