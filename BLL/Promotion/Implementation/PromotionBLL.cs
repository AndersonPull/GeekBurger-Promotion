using System;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BLL.Mapper;
using Contracts.Models.Request;
using Contracts.Models.Response;
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

        public void Create(PromotionRequest model)
        {
            var response = _promotionRepository.Create(_mapper.Map<PromotionEntity>(model));

            var promotion = _mapper.Map<PromotionResponse>(response);
            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Added;
            //TODO buscar produtos
            //TODO mandar para azurebus
        }

        public IEnumerable<PromotionResponse> GetAll()
        {
            var response = _mapper
                .Map<IEnumerable<PromotionResponse>>(_promotionRepository
                .FindAll());

            //TODO buscar produtos

            return response;
        }
            

        public PromotionResponse GetByStoreName(string StoreName)
        {
            var response = _mapper.Map<PromotionResponse>(_promotionRepository.FindByStoreName(StoreName));
            //TODO buscar produtos
            return response;
        }

        public void Update(PromotionRequest model)
        {
            var response = _promotionRepository.Update(_mapper.Map<PromotionEntity>(model));
            var promotion = _mapper.Map<PromotionResponse>(response);

            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Modified;
            //TODO buscar produtos
            //TODO mandar para azurebus
        }

        public void Delete(int value)
        {
            var response = _promotionRepository.FindByID(value);

            var promotion = _mapper.Map<PromotionResponse>(response);
            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Deleted;

            //TODO buscar produtos
            //TODO mandar para azurebus
            _promotionRepository.Delete(value);
        }
    }
}