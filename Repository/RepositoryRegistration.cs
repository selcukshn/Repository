using Repository.Repository.Classes;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(ICreateRepository<>), typeof(CreateRepository<>));
            service.AddScoped(typeof(IGetOneRepository<>), typeof(GetOneRepository<>));
            service.AddScoped(typeof(IGetAllRepository<>), typeof(GetAllRepository<>));
            service.AddScoped(typeof(IUpdateRepository<>), typeof(UpdateRepository<>));
            service.AddScoped(typeof(IDeleteRepository<>), typeof(DeleteRepository<>));
            return service;
        }
    }
}