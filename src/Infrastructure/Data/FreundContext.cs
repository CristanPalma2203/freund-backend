using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FreundContext : DbContext
    {
        public FreundContext(DbContextOptions<FreundContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<DetailSale> DetailSale { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(FreundContext).Assembly);
            base.OnModelCreating(builder);

        }

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries();
            return base.SaveChanges();
        }
    }
}
