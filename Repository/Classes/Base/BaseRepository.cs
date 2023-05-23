using System.Linq.Expressions;
using Repository.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository.Classes.Base
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
        protected DbSet<T> Entity => Context.Set<T>();
        public BaseRepository() { }
        public BaseRepository(DbContext context)
        {
            Context = context;
        }
        public IQueryable<T> AsQueryable() => Entity.AsQueryable();
        protected IQueryable<T> ApplyIncludes(IQueryable<T> entity, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
                foreach (var include in includes)
                {
                    entity = entity.Include(include);
                }
            return entity;
        }
        protected int Save() => Context.SaveChanges();
        protected async Task<int> SaveAsync() => await Context.SaveChangesAsync();
    }
}