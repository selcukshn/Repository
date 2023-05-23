using System.Linq.Expressions;
using Repository.Data.Entity;

namespace Repository.Repository.Interfaces
{
    public interface IDeleteRepository<T> where T : BaseEntity
    {
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(T entity);
        int Delete(Guid id);
        int Delete(T entity);
        Task<int> DeleteRangeAsync(Expression<Func<T, bool>> filter);
        int DeleteRange(Expression<Func<T, bool>> filter);
    }
}