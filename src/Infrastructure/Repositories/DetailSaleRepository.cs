using Domain.Models;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DetailSaleRepository : GenericRepository<DetailSale>, IDetailSaleRepository
    {
        private readonly FreundContext dbContext;
        private readonly IConfiguration configuration;
        public DetailSaleRepository(FreundContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }
    }
}
