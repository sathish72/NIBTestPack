using System;
using BusinessService;
using BusinessService.DTOs;
using BusinessService.Entities;
using DataAccess;
using IsolationLevel = System.Transactions.IsolationLevel;
namespace MoneyBusinessService
{
    public class MoneyService
    {
        private readonly IUnitOfWorkFactory<IMbsContext> _unitOfWorkFactory;

        public MoneyService(IUnitOfWorkFactory<IMbsContext> unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null) throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public MoneyDTO GetMoney(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var money =  new MoneyDA(uow).GetMoney(id);
                return money.To<MoneyDTO>();
            }
        }

        public MoneyDTO UpdateMoney(MoneyDTO moneyDto)
        {
            if (moneyDto == null) throw new ArgumentNullException(nameof(moneyDto));
            if (moneyDto.Id <= 0) throw new ArgumentNullException(nameof(moneyDto.Id));
            var money = moneyDto.To<LoanTracking_Money>();
            using (var uow = _unitOfWorkFactory.Resolve(IsolationLevel.ReadUncommitted))
            {
                var moneyDA = new MoneyDA(uow);
                moneyDA.UpdateMoney(money);
                uow.Complete();
            }
            return GetMoney(moneyDto.Id);
        }
    }
}
