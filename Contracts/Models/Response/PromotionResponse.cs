using System;
using Contracts.Enums;
using Contracts.SwaggerExclude;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Models.Response
{
	public class PromotionResponse
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? StoreName { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "a Imagem é obrigatória.")]
        public string? Image { get; set; }

        public List<ProductResponse>? Products { get; set; } = new List<ProductResponse>();

        [SwaggerExclude]
        public string? ProductsId { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        public decimal Price { get; set; }

        [SwaggerExclude]
        public PromotionStateEnum PromotionState { get; set; }
    }
}

