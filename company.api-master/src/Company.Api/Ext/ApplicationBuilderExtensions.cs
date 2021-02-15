using Microsoft.AspNetCore.Builder;

namespace Company.Api.Middleware
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
