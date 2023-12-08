using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Aplication.Commands.Products;

namespace Aplication.Validators.Products
{
    internal class DeleteProductValidator :  Validador<DeleteProduct>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductValidator(IProductRepository productRepository)
        {
            
            _productRepository = productRepository;

            RuleFor(x => x.Id).NotEmpty().Must(c => ValidateProduc(c)).WithMessage("No existe el producto");
        }

        private bool ValidateProduc(int id)
        {
            var usuario = _productRepository.GetById(id);
            return usuario != null;

        }
        public override IList<string> Permisos => new List<string> {  };

    }
}
