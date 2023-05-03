using System;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BLL.Mapper;
using BLL.Utils;
using Contracts.Models.Request;
using Contracts.Models.Response;
using Repository.Model;
using Repository.SQLServer;
using Repository.SQLServer.Promotion;
using Services.Produtos;

namespace BLL.Promotion.Implementation
{
    public class PromotionBLL : IPromotionBLL
    {
        private readonly IRepository<PromotionEntity> _repository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper = AccessMapper.CreateMapper();
        private readonly IProductService _productServe;

        public PromotionBLL
        (
            IRepository<PromotionEntity> repository,
            IPromotionRepository promotionRepository,
            IProductService productServe
        )
        {
            _repository = repository;
            _promotionRepository = promotionRepository;
            _productServe = productServe;
        }

        public PromotionResponse GetByStoreName(string StoreName)
        {
            var response = _mapper.Map<PromotionResponse>(_promotionRepository.FindByStoreName(StoreName));

            if (response == null)
                return null;

            var products = Util.ConverterStringToListInt(response.ProductsId);

            foreach(var product in products)
                response.Products.Add(_productServe.GetProductById(product));

            return response;
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
            //TODO mandar para azurebus
            _promotionRepository.Delete(value);
        }
    }
}