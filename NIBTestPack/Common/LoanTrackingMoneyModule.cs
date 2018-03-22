using Microsoft.Practices.Unity;
using MoneyBusinessService;

namespace NIBTestPack
{
    public class LoanTrackingMoneyModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<MoneyService>(new HierarchicalLifetimeManager());
        }
    }
}