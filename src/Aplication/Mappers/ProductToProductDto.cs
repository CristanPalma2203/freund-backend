using Aplication.Dtos;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers
{
    public class ProductToProductDto : Profile
    {
        private readonly IProductRepository _productRepository;
        public ProductToProductDto()
        {

            CreateMap<Domain.Models.Product, Dtos.ProductDto>();
            CreateMap<Dtos.ProductDto, Domain.Models.Product>();
            CreateMap<IPagina<Product>, DtoProductPaginados>().ForMember(c => c.Metadata, f => f.MapFrom(c => Getmetadata(c)))
                        .ForMember(c => c.valores, f => f.MapFrom((g, orderDto, i, context) => GetList(g, context)));

        }
        public IList<ProductDto> GetList(IList<Product> products, ResolutionContext context)
        {
            var respuesta = new List<ProductDto>();
            foreach (var product in products)
            {
                var resp = context.Mapper.Map<ProductDto>(product);
                respuesta.Add(resp);
            }

            return respuesta;
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
