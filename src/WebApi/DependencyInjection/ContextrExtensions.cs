using Domain.Repositories;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DependencyInjection
{
    public static class ContextrExtensions
    {
        public static void AddContextConfiguration(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {

            services.AddDbContext<FreundContext>(
         options =>
         {
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

         });

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.Scan(scan => scan.FromAssemblyOf<SaleRepository>().AddClasses(classes => classes.AssignableTo(typeof(IGenericRepository<>))).AsImplementedInterfaces().WithScopedLifetime());

        }
    }
}
