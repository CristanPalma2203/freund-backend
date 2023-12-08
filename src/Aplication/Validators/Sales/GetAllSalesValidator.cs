using Aplication.Commands.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators.Sales
{
    public class GetAllSalesValidator : Validador<GetAllSales>
    {
        public GetAllSalesValidator()
        {
            
        }
        public override IList<string> Permisos => new List<string>();   
    }
}
