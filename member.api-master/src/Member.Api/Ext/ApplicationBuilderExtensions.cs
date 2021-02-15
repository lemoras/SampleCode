using Member.Api.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Member.Api.Ext
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseJwtAuthentication(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<JwtAMiddleware>();
            applicationBuilder.UseAuthentication();
        }
    }
}
