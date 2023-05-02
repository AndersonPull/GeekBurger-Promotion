using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;
using Contracts.Enums;
using Contracts.Models;
using Contracts.SwaggerExclude;
using static System.Net.Mime.MediaTypeNames;

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

        public string? ProductsId { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        public decimal Price { get; set; }

        [SwaggerExclude]
        public PromotionStateEnum PromotionState { get; set; }
    }
}