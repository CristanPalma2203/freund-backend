using Aplication.Dtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers
{
    public class SaleToSaleDto : Profile
    {
        public SaleToSaleDto()
        {
            CreateMap<Domain.Models.Sale, Dtos.SaleDto>().ForMember(c=>c.DetailSales, f=>f.MapFrom(c=>GetRating(c)));
            CreateMap<Dtos.SaleDto, Domain.Models.Sale>();

            CreateMap<IPagina<Sale>, DtoSalesPaginados>()
                .ForMember(c => c.Metadata, f => f.MapFrom(c => Getmetadata(c))).ForMember(c=> c.valores, f=> f.MapFrom((g, orderDto, i, context) => GetList(g, context)));
        }

        public IList<SaleDto> GetList(IList<Sale> servicios, ResolutionContext context)
        {
            var respuesta = new List<SaleDto>();
            foreach (var servicio in servicios)
            {
                var resp = context.Mapper.Map<SaleDto>(servicio);
                respuesta.Add(resp);  
            }
            return respuesta;
        }

        private List<DetailSaleDto> GetRating(Sale sale)
        {
            var lista = new List<DetailSaleDto>();

            if (sale.DetailSales != null)
            {
                foreach (var detail in sale.DetailSales)
                {
                    if (detail.Product != null)
                    {
                        lista.Add(new DetailSaleDto
                        {
                            Id = detail.Id,
                            Quantity = detail.Quantity,
                            ProductId = detail.ProductId,
                            UnitPrice = detail.UnitPrice,
                            Product = new ProductDto
                            {
                                Id = detail.Product.Id,
                                Name = detail.Product.Name,
                                Description = detail.Product.Description,
                                Price = detail.Product.Price,
                                Stock = detail.Product.Stock,
                                Image = detail.Product.Image,

                            }

                        });
                    }
                    else {
                        lista.Add(new DetailSaleDto
                        {
                            Id = detail.Id,
                            Quantity = detail.Quantity,
                            ProductId = detail.ProductId,
                            UnitPrice = detail.UnitPrice

                        });
                    }
                    
                }
            }
            return lista;
        }

        private Metadata Getmetadata<T>(IPagina<T> paging)
        {
            var metada = new Metadata
            {
                CurrentPage = paging.CurrentPage,
                PageSize = paging.PageSize,
                TotalCount = paging.TotalCount,
                TotalPages = paging.TotalPages,
            };
            return metada;
        }

    }
}
