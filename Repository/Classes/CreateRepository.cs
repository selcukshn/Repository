using Repository.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Classes.Base;
using Repository.Repository.Interfaces;
using Repository.Data;

namespace Repository.Repository.Classes
{
    public class CreateRepository<T> : BaseRepository<T>, ICreateRepository<T>
    where T : BaseEntity
    {
        public CreateRepository(MyDbContext context) : base(context) { }

        public int Create(T entity)
        {
            base.Entity.Add(entity);
            return base.Save();
        }

        public int Create(IEnumerable<T> entity)
        {
            base.Entity.AddRange(entity);
            return base.Save();
        }

        public async Task<int> CreateAsync(T entity)
        {
            await base.Entity.AddAsync(entity);
            return await base.SaveAsync();
        }

        public async Task<int> CreateAsync(IEnumerable<T> entity)
        {
            await base.Entity.AddRangeAsync(entity);
            return await base.SaveAsync();
        }
    }
}