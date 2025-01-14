using Finance.Control.Application;
using Finance.Control.Application.Common.Factories;
using Finance.Control.Application.Common.Models;
using Finance.Control.Domain.Entities;
using Finance.Control.Domain.Enum;
using Finance.Control.webApp.Common.DataTables;
using Finance.Control.webApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.webApp.Controllers
{
    [Authorize]
    public class AccountsPayableController(SelectListFactory selectListFactory,
        AccountsPayableService accountsPayableService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new AccountsPayableViewModel
            {
                SelectListStatus = selectListFactory.CreateSelectListStatus(),
                SelectListCategory = selectListFactory.CreateSelectListCategory()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountsPayableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var statusEnum = Enum.Parse<AccountStatus>(model.status);  
                var statusNumber = (int)statusEnum;

                var result = await accountsPayableService.CreateAsync(new Accounts
                {
                    Description = model.Description,
                    Value = model.Value,
                    CreatedAt = DateTime.Now,
                    MaturityDate = model.MaturityDate,
                    CategoryId = model.CategoryId,
                    Status = (AccountStatus)statusNumber,
                });

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<JsonResult> GetDataTables(DataTablesParameterModel model)
        {
            var query = Request.Form["query"].FirstOrDefault();
            const int pageSize = 10;

            var result = await accountsPayableService.GetPagedAppUserAsync(new GetPagedRequest(model.PageNumber, pageSize, query));

            var response = new DataTablesJsonResult<Accounts>(
                model.Draw,
                result.Value.TotalCount,
                result.Value.TotalPages,
                result.Value.Items);

            return Json(response);
        }
    }
}
