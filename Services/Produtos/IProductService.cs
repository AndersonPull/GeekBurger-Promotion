using System;
using Contracts.Models.Response;

namespace Services.Produtos
{
	public interface IProductService
	{
		ProductResponse GetProductById(int id);
	}
}