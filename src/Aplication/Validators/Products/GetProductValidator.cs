using Aplication.Commands.Products;
using Aplication.Validators;
using Domain.Repositories.Extensions;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Aplication.Validators.Products
{
    public class GetProductValidator : Validador<GetProduct>
    {
        public GetProductValidator()
        {

        }
        public override IList<string> Permisos => new List<string>();
    }
}
