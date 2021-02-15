using Microsoft.AspNetCore.Http;
using Member.Domain;

namespace Member.Infrastructure.Context
{
    public class ApplicationContext : IApplicationContext
    {
        private readonly IHttpContextAccessor _httpContext;

        public ApplicationContext(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public int UserId
        {
            get { return !string.IsNullOrWhiteSpace(_httpContext.HttpContext.Request.Headers["UserId"].ToString()) ? int.Parse(_httpContext.HttpContext.Request.Headers["UserId"]) : 0; }
        }

        public string Token
        {
            get { return _httpContext.HttpContext.Request.Headers["Token"]; }
        }
    }
}
