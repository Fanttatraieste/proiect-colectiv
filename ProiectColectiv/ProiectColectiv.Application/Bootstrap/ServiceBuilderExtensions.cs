using Microsoft.Extensions.DependencyInjection;
using ProiectColectiv.Application.Commands.ExampleCommands;
using ProiectColectiv.Application.Commands.PostCommands;
using ProiectColectiv.Application.Interfaces;
using ProiectColectiv.Application.Queries.ExampleQueries;
using ProiectColectiv.Application.Queries.SocialMediaPostQueries;
using ProiectColectiv.Application.Services;

namespace ProiectColectiv.Application.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            services.AddScoped<ExampleQueryHandler>();
            services.AddScoped<ExampleCommandHandler>();
            services.AddScoped<SocialMediaPostQueryHandler>();
            services.AddScoped<PostCommandsHandler>();
        }
    }
}
