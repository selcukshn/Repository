using Repository.Data.Entity;

namespace Repository.Repository.Interfaces
{
    public interface IUpdateRepository<T> where T : BaseEntity
    {
        Task<int> UpdateAsync(T entity);
        int Update(T entity);
    }
}