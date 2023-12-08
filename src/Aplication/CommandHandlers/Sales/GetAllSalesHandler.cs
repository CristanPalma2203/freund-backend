using Aplication.Commands.Products;
using Aplication.Commands.Sales;
using Aplication.Dtos;
using Aplication.Services.Commands;
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
    public class GetAllSalesHandler : AbstractHandler<GetAllSales>
    {
        private readonly IMapper mapper;
        private readonly ISaleRepository saleRepository;
        private readonly IClientRepository clientRepository;
        public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper, IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
            this.saleRepository = saleRepository;
            this.mapper = mapper;
        }

        public override IResponse Handle(GetAllSales message)
        {
            var include = new Includes<Domain.Models.Sale>(new[] { "DetailSales" });
            message.PageNumber = 1;
            message.PageSize = 100;
            var sales = saleRepository.Specify(include).Paginar(message);
            foreach (var item in sales)
            {
                item.Client = searchClient(item.ClientId);
            }


            return mapper.Map<DtoSalesPaginados>(sales);
        }

        private Client searchClient(int id) { 
            
            var client = clientRepository.GetById(id);
            return client;
        
        }

        
    }
    
}
