using Microsoft.Extensions.DependencyInjection;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Services;

namespace ProiectColectiv.Application.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
        }
    }
}
