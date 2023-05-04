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
using Services.ServiceBus;

namespace BLL.Promotion.Implementation
{
    public class PromotionBLL : IPromotionBLL
    {
        private readonly IRepository<PromotionEntity> _repository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper = AccessMapper.CreateMapper();
        private readonly IProductService _productServe;
        private readonly IServiceBus _serviceBus;

        public PromotionBLL
        (
            IRepository<PromotionEntity> repository,
            IPromotionRepository promotionRepository,
            IProductService productServe,
            IServiceBus serviceBus
        )
        {
            _repository = repository;
            _promotionRepository = promotionRepository;
            _productServe = productServe;
            _serviceBus = serviceBus;
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

            var products = Util.ConverterStringToListInt(response.ProductsId);
            foreach (var product in products)
                promotion.Products.Add(_productServe.GetProductById(product));

            _serviceBus.Send("json", "geekburguerpromotion");
        }

        public IEnumerable<PromotionResponse> GetAll()
        {
            var response = _mapper
                .Map<IEnumerable<PromotionResponse>>(_promotionRepository
                .FindAll());

            if (response == null)
                return null;

            foreach (var promotion in response)
            {
                var products = Util.ConverterStringToListInt(promotion.ProductsId);
                foreach (var product in products)
                    promotion.Products.Add(_productServe.GetProductById(product));
            }
            return response;
        }

        public void Update(PromotionRequest model)
        {
            var response = _promotionRepository.Update(_mapper.Map<PromotionEntity>(model));
            var promotion = _mapper.Map<PromotionResponse>(response);
            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Modified;

            var products = Util.ConverterStringToListInt(response.ProductsId);
            foreach (var product in products)
                promotion.Products.Add(_productServe.GetProductById(product));

            _serviceBus.Send("json", "geekburguerpromotion");
        }

        public void Delete(int value)
        {
            var response = _promotionRepository.FindByID(value);

            var promotion = _mapper.Map<PromotionResponse>(response);
            promotion.PromotionState = Contracts.Enums.PromotionStateEnum.Deleted;

            _serviceBus.Send("json", "geekburguerpromotion");

            _promotionRepository.Delete(value);
        }
    }
}