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
    public class CreateProductHandler : AbstractHandler<CreateProduct>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;

        }

        public override IResponse Handle(CreateProduct message)
        {
            var movie = mapper.Map<Domain.Models.Product>(message.Product);
            productRepository.Create(movie);

            return new OkResponse();
        }
    }
}
