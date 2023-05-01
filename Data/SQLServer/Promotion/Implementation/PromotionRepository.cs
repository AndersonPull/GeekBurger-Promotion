using System;
using System.Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.SQLServer.Promotion.Implementation
{
	public class PromotionRepository : IPromotionRepository
    {
        private DataContext _context;

        private DbSet<PromotionEntity> dataset;
        public PromotionRepository(DataContext context)
        {
            _context = context;
            dataset = _context.Set<PromotionEntity>();
        }

        public PromotionEntity FindByStoreName(string storeName)
            => dataset.SingleOrDefault(promotion => promotion.StoreName.Equals(storeName));
    }
}

