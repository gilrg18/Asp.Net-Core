using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareExample.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            List<string> errorMessages = new List<string>();
            string email = string.Empty;
            string password = string.Empty;
            if (httpContext.Request.Path == "/" && httpContext.Request.Method == "POST")
            {
                if (httpContext.Request.Query.ContainsKey("email"))
                {
                    email = httpContext.Request.Query["email"];
                }
                else
                {
                    errorMessages.Add("Invalid input for 'email'");
                }
                if (httpContext.Request.Query.ContainsKey("password"))
                {
                    password = httpContext.Request.Query["password"];
                }
                else
                {
                    errorMessages.Add("Invalid input for 'password'");
                }
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    string validEmail = "admin@example.com";
                    string validPw = "admin1234";
                    if (email == validEmail && password == validPw)
                    {
                        await httpContext.Response.WriteAsync("Successful Login");
                    }
                    else
                    {
                        httpContext.Response.StatusCode = 400;
                        await httpContext.Response.WriteAsync("Invalid Login");
                    }
                }
                if (errorMessages.Count > 0)
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync(string.Join("\n", errorMessages));
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
