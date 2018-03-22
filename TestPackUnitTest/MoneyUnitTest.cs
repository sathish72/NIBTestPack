using System;
using System.Collections.Generic;
using BusinessService.DTOs;
using BusinessService.Entities;
using NIBTestPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyBusinessService;
using Moq;
using Shouldly;

namespace TestPackUnitTest
{
    [TestClass]
    public class MoneyUnitTest
    {


        [ClassInitialize]
        public static void ClassInitialise(TestContext context)
        {
            UnityConfig.RegisterComponents();
            AutoMapperWebConfiguration.Configure();
        }

        [TestMethod]
        public void GetMoney()
        {
            var date = DateTime.UtcNow.Date;
            var service = new MoneyService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));
            var money =service.GetMoney(123);

            money.Id.ShouldBe(123);
            money.Amount.ShouldBe(100000);
            money.ApplicantId.ShouldBe(1);
            money.IsPrimaryLoan.ShouldBe(true);
            money.IsLoDocLoan.ShouldBe(false);
            money.IsFirstHomeBuyer.ShouldBe(false);
            money.IsSelfEmployed.ShouldBe(true);
            money.ProductName.ShouldBe("test1");
            money.ApprovalNumber.ShouldBe("12345");
            money.Balance.ShouldBe(1234568);
            money.ApplicationDate.ShouldBe(date.AddDays(10));
            money.SubmissionDate.ShouldBe(date.AddDays(-10));
        }

        [TestMethod]
        public void UpdateMoney()
        {
            var date = DateTime.UtcNow.Date;
            var service = new MoneyService(new MockUnitOfWorkFactory(GetMockUnitOfWork(date)));

            var moneyDto = new MoneyDTO
            {
                Id = 323,
                Amount = 100000,
                ApplicantId = 1,
                IsPrimaryLoan = true,
                IsLoDocLoan = false,
                IsFirstHomeBuyer = false,
                IsSelfEmployed = true,
                ProductName = "test1",
                ApprovalNumber = "12345",
                Balance = 1234568,
                SubmissionDate = date.AddDays(-10),
                ApplicationDate = date.AddDays(10)
            };


            var money = service.UpdateMoney(moneyDto);

            money.Id.ShouldBe(323);
            money.Amount.ShouldBe(100000);
            money.ApplicantId.ShouldBe(1);
            money.IsPrimaryLoan.ShouldBe(true);
            money.IsLoDocLoan.ShouldBe(false);
            money.IsFirstHomeBuyer.ShouldBe(false);
            money.IsSelfEmployed.ShouldBe(true);
            money.ProductName.ShouldBe("test1");
            money.ApprovalNumber.ShouldBe("12345");
            money.Balance.ShouldBe(1234568);
            money.ApplicationDate.ShouldBe(date.AddDays(10));
            money.SubmissionDate.ShouldBe(date.AddDays(-10));
        }


        private static MockUnitOfWork GetMockUnitOfWork(DateTime date)
        {
            var loan = new List<LoanTracking_Money>
            {
                new LoanTracking_Money
                {
                    Id = 123,
                    Amount = 100000,
                    ApplicantId= 1,
                    IsPrimaryLoan = true,
                    IsLoDocLoan = false,
                    IsFirstHomeBuyer = false,
                    IsSelfEmployed = true,
                    ProductName = "test1",
                    ApprovalNumber = "12345",
                    Balance = 1234568,
                    SubmissionDate = date.AddDays(-10),
                    ApplicationDate = date.AddDays(10),


                },
                new LoanTracking_Money
                {
                    Id = 223,
                    Amount = 200000,
                    ApplicantId= 1,
                    IsPrimaryLoan = true,
                    IsLoDocLoan = false,
                    IsFirstHomeBuyer = false,
                    IsSelfEmployed = true,
                    ProductName = "test1",
                    ApprovalNumber = "12345",
                    Balance = 5234568,
                    SubmissionDate = date.AddDays(-11),
                    ApplicationDate = date.AddDays(11),
                }
               
            };
            


            var mock = new Mock<IMbsContext>();
            var unitOfWork = new MockUnitOfWork(mock.Object);
            unitOfWork.SetRepositoryData(loan);
            return unitOfWork;
        }
    }
}
