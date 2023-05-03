using System;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BLL.Mapper;
using Contracts.Models;
using Repository.Model;
using Repository.SQLServer;
using Repository.SQLServer.Promotion;

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
            var response = _promotionRepository.Create(_mapper.Map<PromotionEntity>(model));

            var promotion = _mapper.Map<PromotionModel>(response);
            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Added;
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
            var response = _promotionRepository.Update(_mapper.Map<PromotionEntity>(model));
            var promotion = _mapper.Map<PromotionModel>(response);

            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Modified;
            //TODO mandar para azurebus
        }

        public void Delete(int value)
        {
            var response = _promotionRepository.FindByID(value);

            var promotion = _mapper.Map<PromotionModel>(response);
            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Deleted;

            //TODO mandar para azurebus
            _promotionRepository.Delete(value);
        }
    }
}