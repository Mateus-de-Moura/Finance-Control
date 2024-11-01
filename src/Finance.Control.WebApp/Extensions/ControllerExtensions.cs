using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.webApp.Extensions
{
    public static class ControllerExtensions
    {
        public static ActionResult RedirectToReference(this Controller controller)
        {
            var url = controller.Request.Headers["Referer"].ToString();

            if (string.IsNullOrEmpty(url))
                return controller.RedirectToAction("Login", "Account");

            return controller.Redirect(url);
        }
    }
}
