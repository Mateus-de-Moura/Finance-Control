using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.webApp.Controllers
{
    public class RevenuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
