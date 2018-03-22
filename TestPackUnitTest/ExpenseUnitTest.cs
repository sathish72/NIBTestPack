using System;
using System.Collections.Generic;
using BusinessService.DTOs;
using BusinessService.Entities;
using NIBTestPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseBusinessService.Implementations;
using Moq;
using Shouldly;

namespace TestPackUnitTest
{
    [TestClass]
    public class ExpenseUnitTest
    {


        [ClassInitialize]
        public static void ClassInitialise(TestContext context)
        {
            UnityConfig.RegisterComponents();
            AutoMapperWebConfiguration.Configure();
        }

        [TestMethod]
        public void GetAllExpense()
        {
            var date = DateTime.UtcNow.Date;
            //var service = new MoneyService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));
            var service = new ExpenseService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));
            var allexpense = service.GetAllExpenses();
        }


        [TestMethod]
        public void GetExpense()
        {
            var date = DateTime.UtcNow.Date;
            //var service = new MoneyService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));
            var service = new ExpenseService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));
            var expense = service.GetExpenseById(456);

            expense.Id.ShouldBe(456);
            expense.Amount.ShouldBeGreaterThan(0);
            expense.ApplicantId.ShouldBeGreaterThanOrEqualTo(1);
            expense.ExpenseType.ShouldBeGreaterThanOrEqualTo(1);
            expense.Frequency.ShouldBeGreaterThanOrEqualTo(1);
        }



        [TestMethod]
        public void UpdateExpense()
        {
            var date = DateTime.UtcNow.Date;
            var service = new ExpenseService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));

            var expenseDto = new ExpenseDTO
            {
                Id = 323,
                Amount = 100000,
                ApplicantId = 1,
                ExpenseType = 2,
                Frequency = 3
            };


            var expense = service.UpdateExpense(expenseDto);

            expense.Id.ShouldBe(457);
            expense.Amount.ShouldBeGreaterThan(0);
            expense.ApplicantId.ShouldBeGreaterThanOrEqualTo(1);
            expense.ExpenseType.ShouldBeGreaterThanOrEqualTo(1);
            expense.Frequency.ShouldBeGreaterThanOrEqualTo(1);
        }

        [TestMethod]
        public void DeleteExpense()
        {
            var date = DateTime.UtcNow.Date;
            var service = new ExpenseService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));

            service.DeleteExpense(457);

        }



        private static MockUnitOfWork GetMockUnitOfWork(DateTime date)
        {
            var loan = new List<LoanTracking_Expense>
            {
                new LoanTracking_Expense
                {
                    Id = 123,
                    Amount = 100000,
                    ApplicantId= 1,
                    ExpenseType = 1,
                    Frequency = 2

                },
                new LoanTracking_Expense
                {
                    Id = 223,
                    Amount = 200000,
                    ApplicantId= 2,
                    ExpenseType = 2,
                    Frequency = 1
                }
               
            };
            


            var mock = new Mock<IMbsContext>();
            var unitOfWork = new MockUnitOfWork(mock.Object);
            unitOfWork.SetRepositoryData(loan);
            return unitOfWork;
        }
    }
}
