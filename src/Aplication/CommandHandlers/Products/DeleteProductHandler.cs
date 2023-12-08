using Aplication.Commands.Products;
using Aplication.Dtos;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CommandHandlers.Products
{
    public class DeleteProductHandler : AbstractHandler<DeleteProduct>
    {
        private readonly IProductRepository productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public override IResponse Handle(DeleteProduct message)
        {
            productRepository.Delete(message.Id);
            return new OkResponse();
        }
    }
}
