using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers
{
    public class DetailSaleDtoToDetailSale : Profile
    {
        public DetailSaleDtoToDetailSale()
        {
            CreateMap<Dtos.DetailSaleDto, Domain.Models.DetailSale>();
            CreateMap<Domain.Models.DetailSale, Dtos.DetailSaleDto>();
        }
    }
}
