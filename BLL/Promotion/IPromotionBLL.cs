using System;
using Contracts.Models;

namespace BLL.Promotion
{
    public interface IPromotionBLL
    {
        PromotionModel GetByStoreName(string StoreName);

        IEnumerable<PromotionModel> GetAll();

        int Create(PromotionModel model);

        void Update(PromotionModel model);

        void Delete(int value);

        void DeleteAll();
    }
}

