using System;
using System.Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.SQLServer.Promotion.Implementation
{
	public class PromotionRepository : GenericRepository<PromotionEntity>, IPromotionRepository
    {
        public PromotionRepository(DataContext context) : base(context) { }

        public PromotionEntity FindByStoreName(string storeName)
            => _context.Promotion.SingleOrDefault(promotion => promotion.StoreName.Equals(storeName));
    }
}

