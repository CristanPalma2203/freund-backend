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
    public class GetSaleHandler : AbstractHandler<GetSale>
    {
        private readonly ISaleRepository saleRepository;
        private readonly IMapper    mapper;
        private readonly IDetailSaleRepository detailSaleRepository;
        private readonly IProductRepository productRepository;
        private readonly IClientRepository clientRepository;
        public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper, IDetailSaleRepository detailSaleRepository, IProductRepository productRepository, IClientRepository clientRepository)
        {
            this.saleRepository = saleRepository;
            this.clientRepository = clientRepository;
            this.mapper         = mapper;
            this.productRepository = productRepository;
            this.detailSaleRepository = detailSaleRepository;
        }

        public override IResponse Handle(GetSale message)
        {

            var sale = saleRepository.GetById(message.Id);

            sale.DetailSales = GetDetailSales(message.Id);
            sale.Client = searchClient(sale.ClientId);
            return mapper.Map<SaleDto>(sale);
        }

        private IList<DetailSale> GetDetailSales(int Id)
        {

            var x = detailSaleRepository.GetAll().Where(x => x.SaleId == Id).ToList();
            foreach (var item in x)
            {
                item.Product = GetProductSales(item.ProductId);
            }
            return x;
        }

        private Product GetProductSales(int Id)
        {
            var x = productRepository.GetById(Id);
            return x;
        }

        private Client searchClient(int id)
        {

            var client = clientRepository.GetById(id);
            return client;

        }
    }
}
