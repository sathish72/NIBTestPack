using BusinessService.Entities;
using DataAccess;
using NIBTestPack;

namespace TestPackUnitTest
{
    public class MockUnitOfWorkFactory : IUnitOfWorkFactory<IMbsContext>
    {
        private readonly IUnitOfWork<IMbsContext> _unitOfWork;

        /// <param name="unitOfWork">Supply a mocked unitOfWork for Lean tests, or leave empty for Lean Data. </param>
        public MockUnitOfWorkFactory(IUnitOfWork<IMbsContext> unitOfWork = null)
        {
            _unitOfWork = unitOfWork;
        }

        public IUnitOfWork<IMbsContext> Resolve(System.Transactions.IsolationLevel? isolationLevel = null)
        {
            if (_unitOfWork != null)
                return _unitOfWork;
            
            return isolationLevel.HasValue ? new UnitOfWork(isolationLevel.Value) : new UnitOfWork();
        }
    }
}