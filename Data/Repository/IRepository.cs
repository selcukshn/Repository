using System.Linq.Expressions;
using Data.Entity;
using static Data.Repository.RepositoryHelper;

namespace Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetQueryable();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<TResult> GetAsync<TResult>(int id, Expression<Func<TEntity, TResult>> selector) where TResult : class;
        Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector) where TResult : class;
        Task<TEntity> GetWithIncludeAsync<TProperty>(int id, Expression<Func<TEntity, TProperty>> include) where TProperty : class;
        Task<TEntity> GetWithIncludeAsync<TProperty>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> include) where TProperty : class;
        IQueryable<TEntity> GetIncluded<TProperty>(int id, Expression<Func<TEntity, TProperty>> include) where TProperty : class;
        Task<ICollection<TEntity>> GetAllAsync();
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class;
        Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class;
        Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class;
        Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class;
        Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include) where TProperty : class;
        Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> filter) where TProperty : class;
        Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class;
        Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class;
        Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class;
        Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class;
        IQueryable<TEntity> GetAllIncluded<TProperty>(Expression<Func<TEntity, TProperty>> include) where TProperty : class;
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task CreateAsync(TEntity entity);
        Task SaveAsync();

    }
}