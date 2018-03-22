using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessService.DTOs;
using ExpenseBusinessService.Contracts;
using NIBTestPack.ActionFilters;

namespace NIBTestPack.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _service;
        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }
        // GET: Expense


        public ActionResult Index(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            List<ApplicantDTO> tempApplicantList = new List<ApplicantDTO>();
            tempApplicantList = _service.GetAllApplicant(); ;
            ViewData["tempApplicantList"] = tempApplicantList;


            List<EnumModel> tempExpenseTypeList = new List<EnumModel>();
            tempExpenseTypeList = _service.GetExpenseType();
            ViewData["tempExpenseTypeList"] = tempExpenseTypeList;


            List<EnumModel> tempFrequencyList = new List<EnumModel>();
            tempFrequencyList = _service.GetFrequency(); 
            ViewData["tempFrequencyList"] = tempFrequencyList;

            var model = _service.GetExpenseById(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateExpense(ExpenseDTO model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var updatedModel = _service.UpdateExpense(model);
            ModelState.Clear();
            return View("EditSummary", updatedModel);
        }

        public JsonResult GetAllApplicants()
        {
            List<ApplicantDTO> result = new List<ApplicantDTO>();
            result = _service.GetAllApplicant(); 
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllExpenseType()
        {
            List<EnumModel> result = new List<EnumModel>();
            result = _service.GetExpenseType();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllFrequency()
        {
            List<EnumModel> result = new List<EnumModel>();
            result = _service.GetFrequency(); ;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllExpenses()
        {
            var result = new OperationResult<IList<ExpenseDTO>>()
            {
                Value = new List<ExpenseDTO>()
            };
            try
            {
                var expenses = _service.GetAllExpenses();
                result.Value = expenses;
            }
            catch (Exception ex)
            {
                //TODO: Log exception
                result.Fail("Error in fetching result");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // GET: Expense/Details/5
        public JsonResult Details(int id)
        {
            var result = new OperationResult<ExpenseDTO>()
            {
                Value = new ExpenseDTO()
            };
            try
            {
                var expense = _service.GetExpenseById(id);
                result.Value = expense;
            }
            catch(Exception ex)
            {
                //Need to log exception
                result.Fail("Error in fetching expense");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Expense/Save
        [HttpPost]
        [ValidateModel]
        //[ValidateAntiForgeryToken]
        public JsonResult Save(ExpenseDTO expense)
        {
            var result = new OperationResult();
            try
            {
                _service.SaveExpense(expense);
            }
            catch(Exception ex)
            {
                //Need to log exception
                result.Fail("Error in saving expense");
            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }

       
        // POST: Expense/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(int Id)
        {
            var result = new OperationResult();
            try
            {
                _service.DeleteExpense(Id);
            }
            catch (Exception ex)
            {
                //Need to log exception
                result.Fail("Error in deleting expense");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
