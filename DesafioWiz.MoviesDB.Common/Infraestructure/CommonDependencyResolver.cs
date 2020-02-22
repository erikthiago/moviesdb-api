using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace DesafioWiz.MoviesDB.Common.Infraestructure
{
    public static class CommonDependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services
                .RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("SharpConfig"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }
    }
}
