using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class SaleDto : IResponse
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public int? ClientId { get; set; }
        public ClientDto? Client { get; set; }
        public IList<DetailSaleDto>? DetailSales { get; set; }
        public double? Total { get; set; }
    }
}
