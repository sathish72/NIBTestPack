using System;
using System.Collections.Generic;
using System.Text;
using BusinessService;
using BusinessService.DTOs;
using ExpenseBusinessService.Contracts;
using DataAccess;
using BusinessService.Entities;
using BusinessService.Enums;
using System.Reflection;
using System.ComponentModel;
using System.Transactions;
using System.Web.Mvc;

namespace ExpenseBusinessService.Implementations
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWorkFactory<IMbsContext> _unitOfWorkFactory;

        public ExpenseService(IUnitOfWorkFactory<IMbsContext> unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public List<ExpenseDTO> GetAllExpenses()
        {
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var expenses = new ExpenseDA(uow).GetAllExpenses();

                var expenseList = expenses.To<List<ExpenseDTO>>();


                foreach (ExpenseDTO lte in expenseList)
                {
                    var expenseTypeDesc = GetEnumDescription((ExpenseTypeEnum)lte.ExpenseType);
                    var frequencyDesc = GetEnumDescription((FrequencyEnum)lte.Frequency);

                    lte.ExpenseTypeDesc = expenseTypeDesc;
                    lte.FrequencyDesc = frequencyDesc;
                }


                return expenseList;

            }
        }

        public List<ApplicantDTO> GetAllApplicant()
        {
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var applicants = new ExpenseDA(uow).GetAllApplicant();

                applicants.Insert(0, new LoanTracking_LoanApplicant { Id = -1, FirstName = "Please select" });
                return applicants.To<List<ApplicantDTO>>();

            }
        }


        public List<EnumModel> GetExpenseType()
        {
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var expensTypes = new ExpenseDA(uow).GetExpenseType();



                return expensTypes;

            }
        }


        public List<EnumModel> GetFrequency()
        {
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var frequencyList = new ExpenseDA(uow).GetFrequency();



                return frequencyList;

            }
        }
        public ExpenseDTO GetExpenseById(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var expense = new ExpenseDA(uow).GetExpenseById(id);
                return expense.To<ExpenseDTO>();
            }
        }

        public void SaveExpense(ExpenseDTO expense)
        {
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var entity = expense.To<LoanTracking_Expense>();
                new ExpenseDA(uow).SaveExpense(entity);
                uow.Complete();
            }
        }

        public ExpenseDTO UpdateExpense(ExpenseDTO expense)
        {
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var entity = expense.To<LoanTracking_Expense>();
                new ExpenseDA(uow).UpdateExpense(entity);
                uow.Complete();
            }

            return expense;
        }

        public void DeleteExpense(int id)
        {
            using (var uow = _unitOfWorkFactory.Resolve())
            {
                var expenseUow = new ExpenseDA(uow);
                var expense = expenseUow.GetExpenseById(id);
                expenseUow.DeleteExpense(expense);
                uow.Complete();
            }
        }
    }
}
