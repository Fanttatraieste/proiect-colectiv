using Microsoft.Extensions.DependencyInjection;
using ProiectColectiv.Domain.Repositories;
using ProiectColectiv.Persistence.Repositories.Base;

namespace ProiectColectiv.Persistence.Bootstrap
{
    public static class ServiceBuilderExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
