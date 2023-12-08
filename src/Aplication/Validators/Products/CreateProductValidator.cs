using Aplication.Commands.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Aplication.Validators.Products
{
    public class CreateProductValidator : Validador<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Product.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Product.Stock).NotEmpty().WithMessage("Stock is required");
        }
        public override IList<string> Permisos => new List<string> {};

    }
}
