using Finance.Control.Application.Common.Models;
using Finance.Control.Application.Dtos;
using Finance.Control.Application.Services;
using Finance.Control.webApp.Common.DataTables;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.webApp.Controllers
{
    public class AppUserController(AppUserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


        public async Task<JsonResult> GetDataTables(DataTablesParameterModel model)
        {
            var query = Request.Form["query"].FirstOrDefault();
            const int pageSize = 10;

            var result = await userService.GetPagedAppUserAsync(new GetPagedRequest(model.PageNumber, pageSize, query));

            var response = new DataTablesJsonResult<AppUserResponseDto>(
                model.Draw,
                result.Value.TotalCount,
                result.Value.TotalPages,
                result.Value.Items);

            return Json(response);
        }
    }
}
