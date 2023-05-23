using System.Linq.Expressions;
using Repository.Data.Entity;

namespace Repository.Repository.Interfaces
{
    public interface IGetOneRepository<T> where T : BaseEntity
    {
        Task<T> GetOneAsync(Guid id);
        Task<T> GetOneAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        T GetOne(Guid id);
        T GetOne(Guid id, params Expression<Func<T, object>>[] includes);
        T GetOne(Expression<Func<T, bool>> filter);
        T GetOne(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
    }
}