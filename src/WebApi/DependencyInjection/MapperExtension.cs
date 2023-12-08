using Aplication.Mappers;
using AutoMapper;
using Domain.Repositories;

namespace WebApi.DependencyInjection
{
    public static class MapperExtension
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddTransient(provider => new MapperConfiguration(cfg =>
            {


                cfg.AddProfile<SaleToSaleDto>();
                cfg.AddProfile<ProductToProductDto>();
                cfg.AddProfile<ClientDtoToClient>();
                cfg.AddProfile<DetailSaleDtoToDetailSale>();
               

            }).CreateMapper());
        }
    }
}
