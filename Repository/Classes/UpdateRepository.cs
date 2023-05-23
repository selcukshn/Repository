using Repository.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Classes.Base;
using Repository.Repository.Interfaces;
using Repository.Data;

namespace Repository.Repository.Classes
{
    public class UpdateRepository<T> : BaseRepository<T>, IUpdateRepository<T>
    where T : BaseEntity
    {
        public UpdateRepository(MyDbContext context) : base(context) { }

        public int Update(T entity)
        {
            base.Entity.Update(entity);
            return base.Save();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            base.Entity.Update(entity);
            return await base.SaveAsync();
        }
    }
}