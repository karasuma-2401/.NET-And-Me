using Microsoft.AspNetCore.Builder;
namespace MyHttpsRedirection
{
    public static class MyHttpsRedirectionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyHttpsRedirection(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyHttpsRedirectionMiddleware>();
        }
    }
}