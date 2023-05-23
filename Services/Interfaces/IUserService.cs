using Repository.Data.Entity;
using Repository.Repository;

namespace Repository.Services.Interfaces
{
    public interface IUserService : IRepository<User>
    {

    }
}