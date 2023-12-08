using Aplication.Dtos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Commands.Sales
{
    public class CreateSale : IMessage
    {
        public SaleDto Sale { get; set; }
      
    }
}
