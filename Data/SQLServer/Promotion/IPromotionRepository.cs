using System;
using Data.Model;

namespace Data.SQLServer.Promotion
{
	public interface IPromotionRepository
	{
        PromotionEntity FindByStoreName(string storeName);
    }
}