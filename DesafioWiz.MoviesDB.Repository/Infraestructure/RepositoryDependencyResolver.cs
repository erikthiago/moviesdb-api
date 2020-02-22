using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace DesafioWiz.MoviesDB.Repository.Infraestructure
{
    public static class RepositoryDependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services
                .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }
    }
}
