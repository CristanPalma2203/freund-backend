using Aplication.Commands.Products;
using Aplication.Commands.Sales;
using Aplication.Dtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.CommandHandlers.Sales
{
    public class CreateSaleHandler : AbstractHandler<CreateSale>
    {
        private readonly IMapper mapper;
        private readonly ISaleRepository saleRepository;
        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            this.saleRepository = saleRepository;
            this.mapper = mapper;

        }
        public override IResponse Handle(CreateSale message)
        {

            List<DetailSale> detailSales = new List<DetailSale>();
            foreach (var item in message.Sale.DetailSales)
            {
                DetailSale x = new DetailSale()
                {
                    ProductId = (int)item.ProductId,
                    Quantity =(int) item.Quantity,
                    UnitPrice = (double)item.UnitPrice
                };

                detailSales.Add(x);
            }
            Sale sale = new Sale() { 
                ClientId = 1,
                Date = DateTime.Now,
                DetailSales = detailSales,
                Total =(double) message.Sale.Total
                
            };
            


            saleRepository.Create(sale);    
            return new OkResponse();
        }
    }
}
