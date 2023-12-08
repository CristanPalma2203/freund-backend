using Aplication.Commands.Products;
using Aplication.Dtos;
using AutoMapper;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CommandHandlers.Products
{
    public class GetProductsHandler : AbstractHandler<GetProducts>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public GetProductsHandler(IProductRepository productRepository , IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;   
        }

        public override IResponse Handle(GetProducts message)
        {
            message.PageNumber = 1;
            message.PageSize = 100;
            var products = productRepository.Paginar(message);

            return mapper.Map<DtoProductPaginados>(products);
        }
    }
}
