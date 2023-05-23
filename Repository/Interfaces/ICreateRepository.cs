using Repository.Data.Entity;

namespace Repository.Repository.Interfaces
{
    public interface ICreateRepository<T> where T : BaseEntity
    {
        Task<int> CreateAsync(T entity);
        Task<int> CreateAsync(IEnumerable<T> entities);
        int Create(T entity);
        int Create(IEnumerable<T> entities);
    }
}