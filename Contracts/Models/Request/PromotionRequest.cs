using System;
using Contracts.Enums;
using Contracts.SwaggerExclude;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Models.Request
{
	public class PromotionRequest
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? StoreName { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "a Imagem é obrigatória.")]
        public string? Image { get; set; }

        public string? ProductsId { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        public decimal Price { get; set; }
    }
}

