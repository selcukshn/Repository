using System.Linq.Expressions;
using Repository.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repository.Classes.Base;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public class Repository<T> : BaseRepository<T>, IRepository<T>
    where T : BaseEntity
    {
        private readonly IGetOneRepository<T> GetOneRepository;
        private readonly IGetAllRepository<T> GetAllRepository;
        private readonly ICreateRepository<T> CreateRepository;
        private readonly IUpdateRepository<T> UpdateRepository;
        private readonly IDeleteRepository<T> DeleteRepository;

        public Repository(IGetAllRepository<T> getAllRepository,
                          ICreateRepository<T> createRepository,
                          IUpdateRepository<T> updateRepository,
                          IDeleteRepository<T> deleteRepository,
                          IGetOneRepository<T> getOneRepository,
                          MyDbContext context) : base(context)
        {
            GetAllRepository = getAllRepository;
            CreateRepository = createRepository;
            UpdateRepository = updateRepository;
            DeleteRepository = deleteRepository;
            GetOneRepository = getOneRepository;
        }

        #region Create
        public int Create(T entity) => CreateRepository.Create(entity);
        public int Create(IEnumerable<T> entities) => CreateRepository.Create(entities);
        public async Task<int> CreateAsync(T entity) => await CreateRepository.CreateAsync(entity);
        public async Task<int> CreateAsync(IEnumerable<T> entities) => await CreateRepository.CreateAsync(entities);
        #endregion

        #region  Delete
        public int Delete(Guid id) => DeleteRepository.Delete(id);
        public int Delete(T entity) => DeleteRepository.Delete(entity);
        public async Task<int> DeleteAsync(Guid id) => await DeleteRepository.DeleteAsync(id);
        public async Task<int> DeleteAsync(T entity) => await DeleteRepository.DeleteAsync(entity);
        public int DeleteRange(Expression<Func<T, bool>> filter) => DeleteRepository.DeleteRange(filter);
        public async Task<int> DeleteRangeAsync(Expression<Func<T, bool>> filter) => await DeleteRepository.DeleteRangeAsync(filter);
        #endregion

        #region GetAll
        public IList<T> GetAll(bool tracking = false) => GetAllRepository.GetAll(tracking);
        public IList<T> GetAll(bool tracking = false, params Expression<Func<T, object>>[] includes) => GetAllRepository.GetAll(tracking, includes);
        public IList<T> GetAll(int count, bool tracking = false) => GetAllRepository.GetAll(count, tracking);
        public IList<T> GetAll(int count, bool tracking = false, params Expression<Func<T, object>>[] includes) => GetAllRepository.GetAll(count, tracking, includes);
        public IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false) => GetAllRepository.GetAll(filter, tracking);
        public IList<T> GetAll(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes) => GetAllRepository.GetAll(filter, tracking, includes);
        public IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false) => GetAllRepository.GetAll(filter, count, tracking);
        public IList<T> GetAll(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes) => GetAllRepository.GetAll(filter, count, tracking, includes);

        public async Task<IList<T>> GetAllAsync(bool tracking = false) => await GetAllRepository.GetAllAsync(tracking);
        public async Task<IList<T>> GetAllAsync(bool tracking = false, params Expression<Func<T, object>>[] includes) => await GetAllRepository.GetAllAsync(tracking, includes);
        public async Task<IList<T>> GetAllAsync(int count, bool tracking = false) => await GetAllRepository.GetAllAsync(count, tracking);
        public async Task<IList<T>> GetAllAsync(int count, bool tracking = false, params Expression<Func<T, object>>[] includes) => await GetAllRepository.GetAllAsync(count, tracking, includes);
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false) => await GetAllRepository.GetAllAsync(filter, tracking);
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool tracking = false, params Expression<Func<T, object>>[] includes) => await GetAllRepository.GetAllAsync(filter, tracking, includes);
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false) => await GetAllRepository.GetAllAsync(filter, count, tracking);
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter, int count, bool tracking = false, params Expression<Func<T, object>>[] includes) => await GetAllRepository.GetAllAsync(filter, count, tracking, includes);
        #endregion

        #region GetOne
        public T GetOne(Guid id) => GetOneRepository.GetOne(id);
        public T GetOne(Guid id, params Expression<Func<T, object>>[] includes) => GetOneRepository.GetOne(id, includes);
        public T GetOne(Expression<Func<T, bool>> filter) => GetOneRepository.GetOne(filter);
        public T GetOne(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes) => GetOneRepository.GetOne(filter, includes);
        public async Task<T> GetOneAsync(Guid id) => await GetOneRepository.GetOneAsync(id);
        public async Task<T> GetOneAsync(Guid id, params Expression<Func<T, object>>[] includes) => await GetOneRepository.GetOneAsync(id, includes);
        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter) => await GetOneRepository.GetOneAsync(filter);
        public async Task<T> GetOneAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes) => await GetOneRepository.GetOneAsync(filter, includes);
        #endregion

        #region Update
        public int Update(T entity) => UpdateRepository.Update(entity);
        public async Task<int> UpdateAsync(T entity) => await UpdateRepository.UpdateAsync(entity);
        #endregion

        #region Have
        public async Task<bool> HaveAsync(Expression<Func<T, bool>> filter)
        {
            return await base.Entity.Where(filter).AnyAsync();
        }
        public bool Have(Expression<Func<T, bool>> filter)
        {
            return base.Entity.Where(filter).Any();
        }
        #endregion

    }
}