using System.Data.SqlTypes;

namespace Inambu_Test_Web.Services
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? GetUserIdFromCookie()
        {
            if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null) return 0;

            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("userId", out string? userIdFromCookie);

            int.TryParse(userIdFromCookie, out int userIDConvertedToInt);

            return userIDConvertedToInt;
        }

        public async Task SetCookies(int userId, string userName)
        {
            if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null) return;

            CookieOptions option = new CookieOptions { Expires = DateTime.Now.AddDays(3) };

            var httpContext = _httpContextAccessor.HttpContext;

            httpContext.Response.Cookies.Append("userId", userId.ToString(), option);
            httpContext.Response.Cookies.Append("userName", userName, option);

        }


    }
}
