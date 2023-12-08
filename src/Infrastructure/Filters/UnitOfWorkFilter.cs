using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Filters
{
    public class UnitOfWorkFilter : IActionFilter
    {
        private readonly IUnitOfWork unitOfWork;
        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

            using (var contexto = unitOfWork.GetContext())
            {

                using (var transaction = contexto.Database.BeginTransaction())
                {
                    Exception exception = context.Exception;

                    if (exception == null)
                    {
                        contexto.SaveChanges();
                        transaction.Commit();

                    }
                    else { transaction.Rollback(); }
                }

            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
