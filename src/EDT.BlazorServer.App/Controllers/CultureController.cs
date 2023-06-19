using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace EDT.BlazorServer.App.Controllers
{
    [Route("[controller]/[action]")]
    public class CultureController : Controller
    {
        public IActionResult Set(string culture, string redirectUri)
        {
            if (!string.IsNullOrWhiteSpace(culture))
            {
                HttpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(
                        new RequestCulture(culture, culture)), 
                    new CookieOptions { Secure = true, HttpOnly = true });
            }

            return LocalRedirect(redirectUri);
        }
    }
}
