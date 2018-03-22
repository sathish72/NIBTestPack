using System.Web.Mvc;
using BusinessService.Entities;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using DataAccess;
using IsolationLevel = System.Transactions.IsolationLevel;
using ExpenseBusinessService.Contracts;
using ExpenseBusinessService.Implementations;

namespace NIBTestPack
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container
                .AddNewExtension<LoanTrackingMoneyModule>()
                .RegisterType<IUnitOfWorkFactory<IMbsContext>, UnitOfWorkFactory>(new HierarchicalLifetimeManager())
                .RegisterType<IUnitOfWork<IMbsContext>, UnitOfWork>("withIsolationLevel",new InjectionConstructor(typeof(IsolationLevel)))
                .RegisterType<IUnitOfWork<IMbsContext>, UnitOfWork>()
                .RegisterType<IExpenseService, ExpenseService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        }
    }


    public class UnitOfWorkFactory : IUnitOfWorkFactory<IMbsContext>
    {
        public IUnitOfWork<IMbsContext> Resolve(IsolationLevel? isolationLevel = null)
        {
            return isolationLevel.HasValue ? new UnitOfWork(isolationLevel.Value) : new UnitOfWork();
        }
    }

    public class UnitOfWork : UnitOfWork<MbsContext>
    {
        public UnitOfWork()
        {
        }

        public UnitOfWork(IsolationLevel isolationLevel) : base(isolationLevel)
        {
        }
    }
}