using Finance.Control.Application.Common.Models;
using Finance.Control.Application.Dtos;
using Finance.Control.Application.Services;
using Finance.Control.webApp.Common.DataTables;
using Finance.Control.webApp.Mappers;
using Finance.Control.webApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Finance.Control.webApp.Controllers
{
    public class AppUserController(AppUserService userService, AppRoleService roleService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var user =  new AppUserViewModel();

            var roles = await roleService.GetAllAsync();

            if (roles != null)
                user.AppRoleSelectListItems = roles.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();

            return View(user);
        }

        public async Task<IActionResult> Edit(Guid AppUserId)
        {
            var appUser = await userService.GetAsync(AppUserId);
            var roles = await roleService.GetAllAsync();

            var user = appUser.Value.MapAppUserResponseToViewModel();

            if (roles != null)
                user.AppRoleSelectListItems = roles.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();

            return View(user);
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

        [HttpPost]
        public async Task<IActionResult> Create(AppUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(model.MapViewModelToDto());

                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));

                else
                {                 
                    ModelState.AddModelError("", result.ValidationErrors.First().ErrorMessage);
                }
            }

            var roles = await roleService.GetAllAsync();

            if (roles != null)
                model.AppRoleSelectListItems = roles.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();


            return View(model);
        }
    }
}
