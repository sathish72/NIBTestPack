using System;
using System.Web.Mvc;
using BusinessService.DTOs;
using MoneyBusinessService;

namespace NIBTestPack.Controllers
{
    public class PeopleController : Controller
    {
        private readonly Lazy<MoneyService> _moneyService;

        public PeopleController(Lazy<MoneyService> moneyService)
        {
            _moneyService = moneyService;
        }
        
        [HttpGet]
        public ActionResult Index(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));

            var model = _moneyService.Value.GetMoney(id);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLoan(MoneyDTO model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var updatedModel= _moneyService.Value.UpdateMoney(model);
            ModelState.Clear();
            return View("EditSummary", updatedModel);
        }
    }
}