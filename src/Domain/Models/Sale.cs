
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public  Client Client { get; set; }
        public IList<DetailSale> DetailSales { get; set; }
        public double Total { get; set; }
    }
}
