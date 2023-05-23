using System.Linq.Expressions;
using Repository.Data.Entity;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public interface IRepository<T> : IGetOneRepository<T>, IGetAllRepository<T>, ICreateRepository<T>, IDeleteRepository<T>, IUpdateRepository<T>
     where T : BaseEntity
    {
        Task<bool> HaveAsync(Expression<Func<T, bool>> filter);
        bool Have(Expression<Func<T, bool>> filter);
    }
}