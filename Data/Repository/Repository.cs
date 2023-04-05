using System.Linq.Expressions;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using static Data.Repository.RepositoryHelper;

namespace Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private MyDbContext Context { get; set; }
        private DbSet<TEntity> Entity => Context.Set<TEntity>();
        public Repository(MyDbContext context)
        {
            this.Context = context;
        }

        private IQueryable<TEntity> EntityById(int id) =>
            Entity.Where(e => e.Id == id);
        private IQueryable<TEntity> EntityByIdWithIncluded<TProperty>(int id, Expression<Func<TEntity, TProperty>> include) where TProperty : class =>
            EntityById(id).Include(include);
        private IQueryable<TEntity> EntityFilter(Expression<Func<TEntity, bool>> filter) =>
            Entity.Where(filter);
        private IQueryable<TEntity> EntityWithIncluded<TProperty>(Expression<Func<TEntity, TProperty>> include) where TProperty : class =>
            Entity.Include(include);

        public IQueryable<TEntity> GetQueryable() =>
            Entity.AsQueryable();


        public async Task<TEntity> GetAsync(int id) =>
            await EntityById(id).SingleOrDefaultAsync();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter) =>
            await Entity.SingleOrDefaultAsync(filter);

        public async Task<TResult> GetAsync<TResult>(int id, Expression<Func<TEntity, TResult>> selector) where TResult : class =>
            await EntityById(id).Select(selector).SingleOrDefaultAsync();

        public async Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector) where TResult : class =>
            await EntityFilter(filter).Select(selector).SingleOrDefaultAsync();


        public async Task<TEntity> GetWithIncludeAsync<TProperty>(int id, Expression<Func<TEntity, TProperty>> include) where TProperty : class =>
            await EntityByIdWithIncluded(id, include).SingleOrDefaultAsync();
        public async Task<TEntity> GetWithIncludeAsync<TProperty>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> include) where TProperty : class =>
            await EntityFilter(filter).Include(include).SingleOrDefaultAsync();

        public IQueryable<TEntity> GetIncluded<TProperty>(int id, Expression<Func<TEntity, TProperty>> include) where TProperty : class =>
            EntityByIdWithIncluded(id, include);


        public async Task<ICollection<TEntity>> GetAllAsync() =>
            await Entity.AsNoTracking().ToListAsync();
        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter) =>
            await EntityFilter(filter).AsNoTracking().ToListAsync();
        public async Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await Entity.OrderBy(order).AsNoTracking().ToListAsync() :
            await Entity.OrderByDescending(order).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, int size) =>
            await EntityFilter(filter).Take(size).AsNoTracking().ToListAsync();
        public async Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await Entity.OrderBy(order).Take(size).AsNoTracking().ToListAsync() :
            await Entity.OrderByDescending(order).Take(size).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await EntityFilter(filter).OrderBy(order).AsNoTracking().ToListAsync() :
            await EntityFilter(filter).OrderByDescending(order).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await EntityFilter(filter).OrderBy(order).Take(size).AsNoTracking().ToListAsync() :
            await EntityFilter(filter).OrderByDescending(order).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include) where TProperty : class =>
            await EntityWithIncluded(include).AsNoTracking().ToListAsync();
        public async Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> filter) where TProperty : class =>
            await EntityWithIncluded(include).Where(filter).AsNoTracking().ToListAsync();

        public async Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await EntityWithIncluded(include).OrderBy(order).AsNoTracking().ToListAsync() :
            await EntityWithIncluded(include).OrderByDescending(order).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> filter, int size) where TProperty : class =>
            await EntityWithIncluded(include).Where(filter).Take(size).AsNoTracking().ToListAsync();
        public async Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await EntityWithIncluded(include).OrderBy(order).Take(size).AsNoTracking().ToListAsync() :
            await EntityWithIncluded(include).OrderByDescending(order).Take(size).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await EntityWithIncluded(include).Where(filter).OrderBy(order).AsNoTracking().ToListAsync() :
            await EntityWithIncluded(include).Where(filter).OrderByDescending(order).AsNoTracking().ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAllWithIncludeAsync<TProperty>(Expression<Func<TEntity, TProperty>> include, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProperty>> order, int size, OrderType orderType = OrderType.ASC) where TProperty : class
        {
            return orderType == OrderType.ASC ?
            await EntityWithIncluded(include).Where(filter).OrderBy(order).Take(size).AsNoTracking().ToListAsync() :
            await EntityWithIncluded(include).Where(filter).OrderByDescending(order).Take(size).AsNoTracking().ToListAsync();
        }
        public IQueryable<TEntity> GetAllIncluded<TProperty>(Expression<Func<TEntity, TProperty>> include) where TProperty : class =>
            EntityWithIncluded(include);
        public void Delete(TEntity entity)
        {
            Entity.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            Entity.Update(entity);
        }
        public async Task CreateAsync(TEntity entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

    }
}