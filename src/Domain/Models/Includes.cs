using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Domain.Models
{
    public sealed class Includes<TEntity> : Specification<TEntity>
    {
        public Includes(IEnumerable<string> includes)
        {
            foreach (var include in includes)
            {
                Query.Include(include);
            }
        }

        public Includes(Expression<Func<TEntity, object>> expression)
        {
            Query.Include(expression);
        }
    }
}
