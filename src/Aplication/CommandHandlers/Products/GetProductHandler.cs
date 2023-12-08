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
    public class GetProductHandler : AbstractHandler<GetProduct>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public override IResponse Handle(GetProduct message)
        {

            var product = productRepository.GetById(message.Id);

            return mapper.Map<ProductDto>(product);
        }
    }
}
