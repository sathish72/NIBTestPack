using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessService.Entities;
using BusinessService.Enums;
using BusinessService.DTOs;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace DataAccess
{
    public class ExpenseDA : BaseEfDataAccess<IMbsContext>
    {
        private readonly IRepository<LoanTracking_Expense> _expenseRepo;
        private readonly IRepository<LoanTracking_LoanApplicant> _applicantRepo;

        public ExpenseDA(IUnitOfWork<IMbsContext> uow) : base(uow)
        {
            _expenseRepo = Uow.GetRepository<LoanTracking_Expense>();
            _applicantRepo = Uow.GetRepository<LoanTracking_LoanApplicant>();
        }

        public LoanTracking_Expense GetExpenseById(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            return _expenseRepo.GetAll().Single(x => x.Id == id);
        }

        public List<LoanTracking_Expense> GetAllExpenses()
        {
            return _expenseRepo.GetAll().ToList();
        }

        public List<LoanTracking_LoanApplicant> GetAllApplicant()
        {
            return _applicantRepo.GetAll().ToList();
        }

        private string GetExpenseTypeName(ExpenseTypeEnum value)
        {
            // Get the MemberInfo object for supplied enum value
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length != 1)
                return null;

            // Get DisplayAttibute on the supplied enum value
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                                   as DisplayAttribute[];
            if (displayAttribute == null || displayAttribute.Length != 1)
                return null;

            return displayAttribute[0].Name;
        }

        private string GetFrequency(FrequencyEnum value)
        {
            // Get the MemberInfo object for supplied enum value
            var memberInfo = value.GetType().GetMember(value.ToString());
            if (memberInfo.Length != 1)
                return null;

            // Get DisplayAttibute on the supplied enum value
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                                   as DisplayAttribute[];
            if (displayAttribute == null || displayAttribute.Length != 1)
                return null;

            return displayAttribute[0].Name;
        }

        public List<EnumModel> GetExpenseType()
        {

            List<EnumModel> enums = ((ExpenseTypeEnum[])Enum.GetValues(typeof(ExpenseTypeEnum))).Select(c => new EnumModel() { Value = (int)c, Name = c.ToString() }).ToList();
            enums.Insert(0, new EnumModel { Value = -1, Name = "Please select" });

            return enums;

            //var selectList = new List<SelectListItem>();

            //// Get all values of the Industry enum
            //var enumValues = Enum.GetValues(typeof(ExpenseTypeEnum)) as ExpenseTypeEnum[];
            //if (enumValues == null)
            //    return null;

            //foreach (var enumValue in enumValues)
            //{
            //    // Create a new SelectListItem element and set its 
            //    // Value and Text to the enum value and description.
            //    selectList.Add(new SelectListItem
            //    {
            //        Value  = enumValue.ToString(),
            //        // GetIndustryName just returns the Display.Name value
            //        // of the enum - check out the next chapter for the code of this function.
            //        Text  = GetExpenseTypeName(enumValue)
            //    });
            //}

            //return selectList.ToList();


        }



        public List<EnumModel> GetFrequency()
        {

            List<EnumModel> enums = ((FrequencyEnum[])Enum.GetValues(typeof(FrequencyEnum))).Select(c => new EnumModel() { Value = (int)c, Name = c.ToString() }).ToList();

            enums.Insert(0, new EnumModel { Value = -1, Name = "Please select" });
            return enums;


            //var selectList = new List<SelectListItem>();

            //// Get all values of the Industry enum
            //var enumValues = Enum.GetValues(typeof(FrequencyEnum)) as FrequencyEnum[];
            //if (enumValues == null)
            //    return null;

            //foreach (var enumValue in enumValues)
            //{
            //    // Create a new SelectListItem element and set its 
            //    // Value and Text to the enum value and description.
            //    selectList.Add(new SelectListItem
            //    {
            //        Value = enumValue.ToString(),
            //        // GetIndustryName just returns the Display.Name value
            //        // of the enum - check out the next chapter for the code of this function.
            //        Text = GetFrequency(enumValue)
            //    });

            //}

            //return selectList.ToList();


        }



        public void SaveExpense(LoanTracking_Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            if (expense.Id != 0)
                _expenseRepo.UpdateWithDetached(expense);
            else
                _expenseRepo.Add(expense);
            Uow.Save();
        }

        public LoanTracking_Expense UpdateExpense(LoanTracking_Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            if (expense.Id != 0)
                _expenseRepo.UpdateWithDetached(expense);
            else
                _expenseRepo.Add(expense);
            Uow.Save();

            return expense;

        }


        public void DeleteExpense(LoanTracking_Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            _expenseRepo.Delete(expense);
            Uow.Save();
        }

    }
}
