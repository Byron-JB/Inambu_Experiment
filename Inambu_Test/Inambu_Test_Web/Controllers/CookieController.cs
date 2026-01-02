using Inambu_Test_Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inambu_Test_Web.Controllers
{
    [Route("cookie")]
    public class CookieController : Controller
    {
        private CookieService _cookieService;

        public CookieController(CookieService cookieService)
        {
            _cookieService = cookieService;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("updatecookie")]
        public async Task<IActionResult> UpdateCookie(int userId, string userName)
        {

            await _cookieService.SetCookies(userId, userName);

            // redirect back to the caller (or to root if no referer)
            var returnUrl = Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(returnUrl)) returnUrl = "/";

            return Redirect(returnUrl);
        }
    }
}
