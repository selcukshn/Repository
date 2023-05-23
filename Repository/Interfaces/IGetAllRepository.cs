using System.Linq.Expressions;
using Repository.Data.Entity;

namespace Repository.Repository.Interfaces
{
    public interface IGetAllRepository<T> where T : BaseEntity
    {
        Task<IList<T>> GetAllAsync(bool tracking = false);
        Task<IList<T>> GetAllAsync(bool tracking = false, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAllAsync(int count, bool tracking = false);
        Task<IList<T>> GetAllAsync(int count, bool tracking = false, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(bool tracking = false);
        IList<T> GetAll(bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(int count, bool tracking = false);
        IList<T> GetAll(int count, bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false);
        IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes);
        IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false);
        IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes);
    }
}