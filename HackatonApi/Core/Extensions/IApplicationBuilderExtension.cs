using ChefApi.Core.Middleware;

namespace HackatonApi.Core.Extensions;

public static class IApplicationBuilderExtension
{
    public static void UseCustomException(this IApplicationBuilder builder) => builder.UseMiddleware<CustomExceptionMiddleware>();

}