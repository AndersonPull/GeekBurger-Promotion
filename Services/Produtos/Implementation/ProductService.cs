using System;
using Contracts.Models.Response;

namespace Services.Produtos.Implementation
{
	public class ProductService : IProductService
	{
		public ProductService()
		{
		}

        //Simulando requisição na api de produto
        public ProductResponse GetProductById(int id)
        {
            var response = new ProductResponse();
            switch (id)
            {
                case 1:
                    response.Id = 1;
                    response.Name = "Big Mac"; 
                    break;
                case 2:
                    response.Id = 2;
                    response.Name = "Quarterão";
                    break;
                case 3:
                    response.Id = 3;
                    response.Name = "McChicken";
                    break;
                default:
                    response.Id = 4;
                    response.Name = "Big Mac";
                    break;
            }

            return response;
        }
    }
}

