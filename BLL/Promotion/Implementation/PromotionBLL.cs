using System;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BLL.Mapper;
using Contracts.Models;
using Data.Model;
using Data.SQLServer;
using Data.SQLServer.Promotion;

namespace BLL.Promotion.Implementation
{
    public class PromotionBLL : IPromotionBLL
    {
        private readonly IRepository<PromotionEntity> _repository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper = AccessMapper.CreateMapper();

        public PromotionBLL(IRepository<PromotionEntity> repository, IPromotionRepository promotionRepository)
        {
            _repository = repository;
            _promotionRepository = promotionRepository;
        }

        public void Create(PromotionModel model)
        {
            _promotionRepository.Create(_mapper.Map<PromotionEntity>(model));
            //TODO buscar produtos
            //TODO mandar para azurebus
        }

        public IEnumerable<PromotionModel> GetAll()
            => _mapper
                .Map<IEnumerable<PromotionModel>>(_promotionRepository
                .FindAll());

        public PromotionModel GetByStoreName(string StoreName)
            => _mapper.Map<PromotionModel>(_promotionRepository.FindByStoreName(StoreName));

        public void Update(PromotionModel model)
        {
            _promotionRepository.Create(_mapper.Map<PromotionEntity>(model));
            //TODO buscar produtos
            //TODO mandar para azurebus
        }

        public void Delete(int value)
        {
            _promotionRepository.FindByID(value);
            //TODO buscar produtos
            //TODO mandar para azurebus
            _promotionRepository.Delete(value);
        }
    }
}

