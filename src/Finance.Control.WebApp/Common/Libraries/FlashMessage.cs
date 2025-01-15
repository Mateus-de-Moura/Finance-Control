using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Finance.Control.webApp.Common.Libraries
{
    public static class FlashMessage
    {
        private static readonly IList<string> Messages = new List<string>();

        private static void SetMessage(string text, string icon)
        {
            var title = text
                .Replace("'", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty)
                .Replace("\\", "\\\\");

            var script = $@"
            <script>
                Swal.fire({{
                  text: ""{text}"",
                  icon: ""{icon}"",
                  toast: true,
                  position: 'top-end',
                  showConfirmButton: false,
                  timer: 3000,
                  timerProgressBar: true
                }});
            </script>";

            Messages.Add(script);
        }

        public static void Success(string text)
        {
            SetMessage(text, "success");
        }

        public static void Info(string text)
        {
            SetMessage(text, "info");
        }

        public static void Error(string text)
        {
            SetMessage(text, "error");
        }

        public static void Warning(string text)
        {
            SetMessage(text, "warning");
        }

        public static HtmlString RenderFlashMessage(this IHtmlHelper htmlHelper)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            if (Messages.Any())
            {
                var html = string.Join(string.Empty, Messages.Select(x => x));

                Messages.Clear();

                return new HtmlString(html);
            }

            return new HtmlString(string.Empty);
        }
    }
}
