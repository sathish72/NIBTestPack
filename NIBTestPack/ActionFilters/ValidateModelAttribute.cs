using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using BusinessService.DTOs;

namespace NIBTestPack.ActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var result = new OperationResult();
            var viewData = context.Controller.ViewData;
            if (!viewData.ModelState.IsValid)
            {
                foreach (var state in viewData.ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        result.Fail(error.ErrorMessage);
                    }
                }

                context.Result = new JsonResult() { Data = result };
            }
            base.OnActionExecuting(context);
        }
    }
}