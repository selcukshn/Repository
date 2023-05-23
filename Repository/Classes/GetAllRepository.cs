using System.Linq.Expressions;
using Repository.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Classes.Base;
using Repository.Repository.Interfaces;
using Repository.Data;

namespace Repository.Repository.Classes
{
    public class GetAllRepository<T> : BaseRepository<T>, IGetAllRepository<T>
    where T : BaseEntity
    {
        public GetAllRepository(MyDbContext context) : base(context) { }

        public IList<T> GetAll(bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(int count, bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }

        public IList<T> GetAll(int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }
        public IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.ToList();
        }
        public IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return entity.Take(count).ToList();
        }
        public async Task<IList<T>> GetAllAsync(bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(int count, bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.ToListAsync();
        }
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false)
        {
            var entity = base.AsQueryable();
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var entity = base.AsQueryable();
            entity = base.ApplyIncludes(entity, includes);
            if (filter != null)
                entity = entity.Where(filter);
            if (!tracking)
                entity = entity.AsNoTracking();
            return await entity.Take(count).ToListAsync();
        }
    }
}