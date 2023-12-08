using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class DetailSaleDto
    {
        public int? Id { get; set; }
        public int? SaleId { get; set; }
        public SaleDto? Sale { get; set; }
        public int? ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
    }
}
