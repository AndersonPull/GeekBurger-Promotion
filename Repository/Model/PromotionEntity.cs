using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Model
{
	public class PromotionEntity : BaseEntity
    {
        public string? StoreName { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? ProductsId { get; set; }

        public decimal Price { get; set; }
    }
}

