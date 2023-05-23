using Repository.Data;
using Repository.Data.Entity;
using Repository.Repository;
using Repository.Repository.Interfaces;
using Repository.Services.Interfaces;

namespace Repository.Services.Classes
{
    public class UserService : Repository<User>, IUserService
    {
        public UserService(IGetAllRepository<User> getAllRepository,
                           ICreateRepository<User> createRepository,
                           IUpdateRepository<User> updateRepository,
                           IDeleteRepository<User> deleteRepository,
                           IGetOneRepository<User> getOneRepository,
                           MyDbContext context) : base(getAllRepository, createRepository, updateRepository, deleteRepository, getOneRepository, context) { }
    }
}