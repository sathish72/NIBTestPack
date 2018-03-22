using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService.Entities;

namespace DataAccess
{
    public class BaseEfDataAccess<TContext>  where TContext : IBaseContext
    {
        protected IUnitOfWork<TContext> Uow { get; private set; }

        public BaseEfDataAccess()
        {
        }

        public BaseEfDataAccess(IUnitOfWork<TContext> uow)
        {
            Uow = uow;
        }
    }
}
