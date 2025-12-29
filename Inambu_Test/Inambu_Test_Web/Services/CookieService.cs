using Microsoft.AspNetCore.DataProtection;
using System.Data.SqlTypes;

namespace Inambu_Test_Web.Services
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDataProtector _protector;

        public CookieService(IHttpContextAccessor httpContextAccessor, IDataProtectionProvider provider)
        {
            _httpContextAccessor = httpContextAccessor;
            _protector = provider.CreateProtector("MyCookieProtector");
        }

        /// <summary>
        /// Retrieves the user ID from the current HTTP request's cookies.
        /// </summary>
        /// <remarks>If the HTTP context or the "userId" cookie is missing, or if the cookie value cannot
        /// be parsed as an integer, the method returns 0. This method does not throw exceptions for missing or invalid
        /// cookie values.</remarks>
        /// <returns>The user ID as an integer if the "userId" cookie is present and contains a valid integer value; otherwise,
        /// 0.</returns>
        public int? GetUserIdFromCookie()
        {
            try
            {
                if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null) return 0;

                _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("userId", out string? userIdFromCookie);

                int.TryParse(userIdFromCookie, out int userIDConvertedToInt);

                return Unprotect(userIDConvertedToInt);
            }
            catch (Exception)
            {

                return 0;
            }
        }

        /// <summary>
        /// Retrieves the user name stored in the current HTTP request's cookies, if available.
        /// </summary>
        /// <remarks>This method attempts to read the "userName" cookie from the current HTTP context and
        /// returns its value after unprotecting it. If the HTTP context is unavailable or the cookie is missing or
        /// invalid, the method returns null.</remarks>
        /// <returns>The user name extracted from the "userName" cookie if present and successfully unprotected; otherwise, null.</returns>
        public string? GetUserNameFromCookie()
        {
            try
            {
                if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null) return null;

                _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("userName", out string? userNameFromCookie);
                if (string.IsNullOrEmpty(userNameFromCookie)) return null;
                return Unprotect(userNameFromCookie);
            }
            catch (Exception)
            {

                return null;
            }
        }


        /// <summary>
        /// Sets authentication cookies for the specified user in the current HTTP response.
        /// </summary>
        /// <remarks>The cookies are set to expire in three days from the time they are created. This
        /// method requires a valid HTTP context; if the context is unavailable, no cookies are set.</remarks>
        /// <param name="userId">The unique identifier of the user for whom the cookies are to be set.</param>
        /// <param name="userName">The name of the user to be stored in the authentication cookie. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation of setting the cookies.</returns>
        public async Task SetCookies(int userId, string userName)
        {
            if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null) return;

            CookieOptions option = new CookieOptions { Expires = DateTime.Now.AddDays(3) };

            var httpContext = _httpContextAccessor.HttpContext;

            httpContext.Response.Cookies.Append("userId", Protect(userId.ToString()), option);
            httpContext.Response.Cookies.Append("userName", Protect(userName), option);

        }

        /// <summary>
        /// Encrypts the specified input string to protect its contents.
        /// </summary>
        /// <param name="input">The plain text string to be encrypted. Cannot be null.</param>
        /// <returns>A protected string containing the encrypted representation of the input.</returns>
        private string Protect(string input) => _protector.Protect(input);

        /// <summary>
        /// Removes protection from the specified input string and returns the original unprotected value.
        /// </summary>
        /// <param name="input">The protected string to unprotect. Cannot be null.</param>
        /// <returns>The original, unprotected string that was previously protected.</returns>
        private string Unprotect(string input) => _protector.Unprotect(input);

        /// <summary>
        /// Attempts to remove protection from the specified integer value and return the original unprotected value.
        /// </summary>
        /// <remarks>If the input cannot be unprotected or converted to an integer, the method returns 0.
        /// This method does not throw exceptions for invalid input or unprotection failures.</remarks>
        /// <param name="input">The integer value to unprotect.</param>
        /// <returns>The unprotected integer value if successful; otherwise, 0.</returns>
        private int? Unprotect(int input)
        {
            try
            {
                var unprotectedString = _protector.Unprotect(input.ToString());
                if (int.TryParse(unprotectedString, out int result))
                {
                    return result;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
