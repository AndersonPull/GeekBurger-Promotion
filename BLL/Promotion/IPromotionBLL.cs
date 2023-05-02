using System;
using Contracts.Models;

namespace BLL.Promotion
{
    public interface IPromotionBLL
    {
        PromotionModel GetByStoreName(string StoreName);

        IEnumerable<PromotionModel> GetAll();

        void Create(PromotionModel model);

        void Update(PromotionModel model);

        void Delete(int value);
    }
}

