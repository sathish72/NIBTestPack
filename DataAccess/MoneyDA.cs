using System;
using System.Linq;
using BusinessService.Entities;

namespace DataAccess
{
    public class MoneyDA : BaseEfDataAccess<IMbsContext>
    {
        private readonly IRepository<LoanTracking_Money> _loanTrackingMoney;

        public MoneyDA(IUnitOfWork<IMbsContext> uow) : base(uow)
		{
            _loanTrackingMoney = Uow.GetRepository<LoanTracking_Money>();
        }

        public LoanTracking_Money GetMoney(int loanId)
        {
            if (loanId <= 0) throw new ArgumentOutOfRangeException(nameof(loanId));
            return _loanTrackingMoney.GetAll().FirstOrDefault(x => x.Id == loanId);
        }

        public void UpdateMoney(LoanTracking_Money loan)
        {
            if (loan == null) throw new ArgumentNullException(nameof(loan));
            if (loan.Id <= 0) throw new ArgumentOutOfRangeException(nameof(loan.Id));
            _loanTrackingMoney.UpdateWithDetached(loan);
            Uow.Save();
        }
    }
}
