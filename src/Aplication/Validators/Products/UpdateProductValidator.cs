using Aplication.Commands.Products;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Aplication.Validators.Products
{
    public class UpdateProductValidator : Validador<UpdateProduct>
	{
        private readonly IProductRepository _productRepository;

        public UpdateProductValidator(IProductRepository productRepository)
        {
			_productRepository = productRepository;
			RuleFor(x => x.Product.Id).NotEmpty().Must(c => ValidateProduc(c)).WithMessage("No existe el producto");
		}
		private bool ValidateProduc(int id)
		{
			var usuario = _productRepository.GetById(id);
			return usuario != null;

		}
		public override IList<string> Permisos => new List<string> { };
	}
}
