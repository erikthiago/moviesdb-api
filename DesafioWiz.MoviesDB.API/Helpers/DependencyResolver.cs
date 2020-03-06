using DesafioWiz.MoviesDB.Common.Infraestructure;
using DesafioWiz.MoviesDB.Repository.Infraestructure;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioWiz.MoviesDB.API.Helpers
{
    public class DependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            CommonDependencyResolver.RegisterServices(services);
            RepositoryDependencyResolver.RegisterServices(services);
        }
    }
}
