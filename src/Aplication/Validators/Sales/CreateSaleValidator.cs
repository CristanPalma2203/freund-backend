using Aplication.Commands.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators.Sales
{
    public  class CreateSaleValidator: Validador<CreateSale>
    {
        public CreateSaleValidator()
        {
            
        }
        public override IList<string> Permisos => new List<string>();   
    }
}
