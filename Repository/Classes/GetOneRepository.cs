using System.Linq.Expressions;
using Repository.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Classes.Base;
using Repository.Repository.Interfaces;
using Repository.Data;

namespace Repository.Repository.Classes
{
    public class GetOneRepository<T> : BaseRepository<T>, IGetOneRepository<T>
    where T : BaseEntity
    {
        public GetOneRepository(MyDbContext context) : base(context) { }

        public T GetOne(Guid id)
        {
            return base.Entity.Find(id);
        }

        public T GetOne(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            return entity.SingleOrDefault(e => e.Id == id);
        }
        public T GetOne(Expression<Func<T, bool>> filter)
        {
            return base.Entity.FirstOrDefault(filter);
        }

        public T GetOne(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            return entity.FirstOrDefault(filter);
        }
        public async Task<T> GetOneAsync(Guid id)
        {
            return await base.Entity.FindAsync(id);
        }
        public async Task<T> GetOneAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            return await entity.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            return await base.Entity.FirstOrDefaultAsync(filter);
        }


        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var entity = this.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            return await entity.FirstOrDefaultAsync(filter);
        }
    }
}