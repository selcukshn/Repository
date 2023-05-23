using System.Linq.Expressions;
using Repository.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Classes.Base;
using Repository.Repository.Interfaces;
using Repository.Data;

namespace Repository.Repository.Classes
{
    public class DeleteRepository<T> : BaseRepository<T>, IDeleteRepository<T>
    where T : BaseEntity
    {
        public DeleteRepository(MyDbContext context) : base(context) { }

        public int Delete(T entity)
        {
            base.Entity.Remove(entity);
            return base.Save();
        }
        public int Delete(Guid id)
        {
            return this.Delete(base.Entity.Find(id));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await this.DeleteAsync(await base.Entity.FindAsync(id));
        }

        public async Task<int> DeleteAsync(T entity)
        {
            base.Entity.Remove(entity);
            return await base.SaveAsync();
        }

        public int DeleteRange(Expression<Func<T, bool>> filter)
        {
            base.Context.RemoveRange(base.Entity.Where(filter));
            return base.Save();
        }

        public async Task<int> DeleteRangeAsync(Expression<Func<T, bool>> filter)
        {
            base.Context.RemoveRange(base.Entity.Where(filter));
            return await base.SaveAsync();
        }
    }
}