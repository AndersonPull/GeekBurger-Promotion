using System;
using Contracts.SwaggerExclude;

namespace Contracts.Models
{
	public class ProductModel
	{
        [SwaggerExclude]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}

