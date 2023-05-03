using System;
using Contracts.Models.Request;
using Contracts.Models.Response;

namespace BLL.Promotion
{
    public interface IPromotionBLL
    {
        PromotionResponse GetByStoreName(string StoreName);

        IEnumerable<PromotionResponse> GetAll();

        void Create(PromotionRequest model);

        void Update(PromotionRequest model);

        void Delete(int value);
    }
}

