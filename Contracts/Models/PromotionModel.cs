using System;
using System.ComponentModel.DataAnnotations;
using Contracts.SwaggerExclude;

namespace Contracts.Models
{
	public class PromotionModel
	{
        [SwaggerExclude]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? StoreName { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "a Imagem é obrigatória.")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "o produto é obrigatóri0.")]
        public List<ProductModel>? Product { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        public decimal Price { get; set; }
    }
}

