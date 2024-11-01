using Finance.Control.Application;
using Finance.Control.Infra.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Finance.Control.webApp
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMiniProfiler();

            services
                 .AddControllersWithViews()
                 .AddRazorRuntimeCompilation();

            services
                 .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                 {
                     options.ExpireTimeSpan = TimeSpan.FromHours(24);
                     options.Cookie.MaxAge = options.ExpireTimeSpan;
                     options.SlidingExpiration = true;
                     options.LoginPath = "/Account/Login";
                     options.AccessDeniedPath = "/Account/AccessDenied";
                 });

            services.AddInfrastructureServices(configuration)
                .AddApplicationServices(configuration);           

        }
    }
}
