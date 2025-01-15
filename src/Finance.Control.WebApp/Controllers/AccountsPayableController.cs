using Finance.Control.Application;
using Finance.Control.Application.Common.Factories;
using Finance.Control.Application.Common.Models;
using Finance.Control.Domain.Entities;
using Finance.Control.Domain.Enum;
using Finance.Control.webApp.Common.DataTables;
using Finance.Control.webApp.Common.Libraries;
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
                    Active = model.Active,
                    Description = model.Description,
                    Value = Convert.ToDecimal(model.Value),
                    CreatedAt = DateTime.Now,
                    MaturityDate = model.MaturityDate,
                    CategoryId = model.CategoryId,
                    Status = (AccountStatus)statusNumber,
                });

                FlashMessage.Success("Cadastrado com Sucesso");

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(Guid AccountPayableId)
        {
            var result = await accountsPayableService.GetById(AccountPayableId);

            if (result.IsSuccess)
            {
                var account = result.Value;

                var model = new AccountsPayableViewModel
                {
                    Id = account.Id,
                    Active = account.Active,
                    Description = account.Description,
                    Value = account.Value.ToString(),
                    MaturityDate = account.MaturityDate,
                    CategoryId = account.CategoryId,
                    status = account.Status.ToString(),
                    SelectListStatus = selectListFactory.CreateSelectListStatus(),
                    SelectListCategory = selectListFactory.CreateSelectListCategory()
                };

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountsPayableViewModel model)
        {
            model.SelectListStatus = selectListFactory.CreateSelectListStatus();
            model.SelectListCategory = selectListFactory.CreateSelectListCategory();

            if (ModelState.IsValid)
            {
                var statusEnum = Enum.Parse<AccountStatus>(model.status);
                var statusNumber = (int)statusEnum;

                var result = await accountsPayableService.UpdateAsync(new Accounts
                {
                    Id = model.Id,
                    Active = model.Active,
                    Description = model.Description,
                    Value = Convert.ToDecimal(model.Value),
                    CreatedAt = DateTime.Now,
                    MaturityDate = model.MaturityDate,
                    CategoryId = model.CategoryId,
                    Status = (AccountStatus)statusNumber,
                });

                if (result.IsSuccess)
                {
                    FlashMessage.Success("Atualizado com Sucesso");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    FlashMessage.Error("Erro ao cadastrar conta");
                    return View(model);
                }
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
