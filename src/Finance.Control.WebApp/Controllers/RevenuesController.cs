using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.webApp.Controllers
{
    [Authorize]
    public class RevenuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
