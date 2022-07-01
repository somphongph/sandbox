using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace Domain.Middleware
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var cultureCode = context.Request.Query["lang"];
            if (string.IsNullOrWhiteSpace(cultureCode))
            {
                cultureCode = context.Request.Headers["Accept-Language"];
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureCodeToStandardCultureCode(cultureCode));

            return this._next(context);
        }

        private string CultureCodeToStandardCultureCode(string letter)
        {
            letter = (letter ?? String.Empty).Trim().ToLower();

            switch (letter)
            {
                case "en":
                case "en-us":
                    return "en-US";
                case "th":
                case "th-th":
                    return "th-TH";
                case "cn":
                case "zh-cn":
                    return "zh-CN";
                default:
                    return "en-US";
            }
        }
    }
}