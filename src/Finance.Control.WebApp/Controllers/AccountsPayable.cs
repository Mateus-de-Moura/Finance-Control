using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.webApp.Controllers
{
    public class AccountsPayable : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
