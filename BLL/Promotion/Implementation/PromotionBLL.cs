using System;
using Contracts.Models;

namespace BLL.Promotion.Implementation
{
    public class PromotionBLL : IPromotionBLL
    {
        //private readonly PromotionData _data;

        public PromotionBLL()
        {
            //_data = new PromotionData();
        }

        public int Create(PromotionModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int value)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PromotionModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PromotionModel GetByStoreName(string StoreName)
        {
            var response = new PromotionModel()
            {
                Id = 1,
                StoreName = "Morumbi",
                Image = "imagem.jpg",
                Name = "SuperPromocao",
                ProductsId = "222,222,22",
                Price = 10
            };

            return response;
        }

        public void Update(PromotionModel model)
        {
            throw new NotImplementedException();
        }
    }
}

