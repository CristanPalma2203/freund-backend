using Domain.Repositories.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        TEntity Update(int id, TEntity entity);
        TEntity Delete(int id);
        IPagina<TEntity> Paginar(IConsulta ownerParameters);
        IGenericRepository<TEntity> Specify(Ardalis.Specification.ISpecification<TEntity> specification);

    }
}
