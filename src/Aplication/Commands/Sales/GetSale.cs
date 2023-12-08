using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Commands.Sales
{
    public class GetSale : IMessage
    {
        public int Id { get; set; }
    }
}
