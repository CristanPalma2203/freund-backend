using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Extensions;
using Infrastructure.Data;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using Ardalis.Specification.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly FreundContext _dbContext;
        private List<Ardalis.Specification.ISpecification<TEntity>> Specs { get; }
        public GenericRepository(FreundContext dbContext)
        {
            Specs = new List<Ardalis.Specification.ISpecification<TEntity>>();
            _dbContext = dbContext;
        }
        public TEntity Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return entity;
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            var resultado = _dbContext.Set<TEntity>().AsNoTracking().Where(predicate);

            return resultado;
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public TEntity Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return entity;
        }
        public IQueryable<TEntity> WithSpecs()
        {
            var query = _dbContext.Set<TEntity>().OrderBy(on => on.Id).AsQueryable();
            var queryable = Specs.Aggregate(query,
                (current, spec) => new SpecificationEvaluator<TEntity>().GetQuery(current, spec));
            Specs.Clear();
            return queryable;
        }
        public IPagina<TEntity> Paginar(IConsulta ownerParameters)
        {
            var ff = PagedList<TEntity>.ToPagedList(WithSpecs().AsQueryable(),
                ownerParameters.PageNumber,
                ownerParameters.PageSize);
            return ff;
        }

        public IGenericRepository<TEntity> Specify(Ardalis.Specification.ISpecification<TEntity> specification)
        {
            this.Specs.Add(specification);
            return this;
        }
    }
}
