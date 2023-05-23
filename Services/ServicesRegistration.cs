using Repository.Services.Classes;
using Repository.Services.Interfaces;

namespace Repository.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            return service;
        }
    }
}