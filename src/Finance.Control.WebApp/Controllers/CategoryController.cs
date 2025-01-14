using Finance.Control.Application.Common.Models;
using Finance.Control.Application.Dtos;
using Finance.Control.Application.Services;
using Finance.Control.Domain.Entities;
using Finance.Control.webApp.Common.DataTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.webApp.Controllers
{
    [Authorize]
    public class CategoryController(CategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var result = await categoryService.CreateCategoryAsync(category);

            if (result.IsSuccess)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError("Name", "Ja existe uma categoria com esse nome.");

            return View(category);
        }


        public async Task<IActionResult> Edit(Guid CategoryId)
        {
            var result = await categoryService.GetById(CategoryId);

            if (result.IsSuccess)
                return View(result.Value);
            else
                return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var result = await categoryService.UpdateCategory(category);

            if (!result.IsSuccess)
                return View(result.Value);
            else
                return RedirectToAction(nameof(Index));

        }


        public async Task<JsonResult> GetDataTables(DataTablesParameterModel model)
        {
            var query = Request.Form["query"].FirstOrDefault();
            const int pageSize = 10;

            var result = await categoryService.GetPagedAppUserAsync(new GetPagedRequest(model.PageNumber, pageSize, query));

            var response = new DataTablesJsonResult<Category>(
                model.Draw,
                result.Value.TotalCount,
                result.Value.TotalPages,
                result.Value.Items);

            return Json(response);
        }
    }
}
