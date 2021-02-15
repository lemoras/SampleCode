using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Company.Api.Middleware
{
    public class JwtAMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtAMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            //context.Request.Headers.Add("Authorization", "Bearer " + "OsmEmrBarber123");

            return _next(context);
        }
    }
}
