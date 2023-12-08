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
    internal class UpdateProductHandler : AbstractHandler<UpdateProduct>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            
        }

        public override IResponse Handle(UpdateProduct message)
        {
            var prodcutOld = productRepository.GetById(message.Product.Id);
            var prodcutNew = mapper.Map<Domain.Models.Product>(message.Product);
            productRepository.Update(prodcutOld.Id, prodcutNew);

            return mapper.Map<ProductDto>(prodcutNew);
        }
    }
}
