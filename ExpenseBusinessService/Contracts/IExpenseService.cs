using System.Collections.Generic;
using BusinessService.DTOs;
using BusinessService.Enums;
using System.Web.Mvc;

namespace ExpenseBusinessService.Contracts
{
    public interface IExpenseService
    {
        ExpenseDTO GetExpenseById(int id);
        List<ExpenseDTO> GetAllExpenses();

        List<ApplicantDTO> GetAllApplicant();

        void SaveExpense(ExpenseDTO expense);

        ExpenseDTO UpdateExpense(ExpenseDTO expense);

        void DeleteExpense(int id);

        List<EnumModel> GetExpenseType();

        List<EnumModel> GetFrequency();

    }
}