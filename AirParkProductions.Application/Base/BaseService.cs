using MySqlConnector;
using AirParkProductions.Domain.Base;
using AirParkProductions.Domain.Request;
using AirParkProductions.Infrastructure.Base;
using System.Linq.Expressions;

namespace AirParkProductions.Application.Base
{
    public class BaseService<TRepository, T> : IBaseService<T>
        where TRepository : IBaseRepository<T>
        where T : BaseEntity
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<T> GetBy(Expression<Func<T, bool>> where)
        {
            return await _repository.GetBy(where);
        }

        public async Task<T> GetBy(IBaseSpecifications<T> baseSpecifications)
        {
            return await _repository.GetBy(baseSpecifications);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where)
        {
            return await _repository.GetAllAsync(where);
        }
        public async Task<List<T>> GetAllAsync(IBaseSpecifications<T> baseSpecifications = null)
        {
            return await _repository.GetAllAsync(baseSpecifications);
        }

        public async Task<List<T>> GetAllAsync(string query, IBaseSpecifications<T> baseSpecifications = null)
        {
            return await _repository.GetAllAsync(query, baseSpecifications);
        }

        public async Task<List<T>> GetAllAsync(string query, List<MySqlParameter> parameters, IBaseSpecifications<T> baseSpecifications = null)
        {
            return await _repository.GetAllAsync(query, parameters, baseSpecifications);
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> where)
        {
            return _repository.GetAllQueryable(where);
        }
        public IQueryable<T> GetAllQueryable(IBaseSpecifications<T> baseSpecifications = null)
        {
            return _repository.GetAllQueryable(baseSpecifications);
        }

        public IQueryable<T> GetAllQueryable(string query, IBaseSpecifications<T> baseSpecifications = null)
        {
            return _repository.GetAllQueryable(query, baseSpecifications);
        }

        public IQueryable<T> GetAllQueryable(string query, List<MySqlParameter> parameters, IBaseSpecifications<T> baseSpecifications = null)
        {
            return _repository.GetAllQueryable(query, parameters, baseSpecifications);
        }

        public async Task<List<TEntity>> GetAllByQueryable<TEntity>(IQueryable<TEntity> query)
        {
            return await _repository.GetAllByQueryable(query);
        }

        public async Task<decimal> CountAllAsync(Expression<Func<T, bool>> where)
        {
            return await _repository.CountAllAsync(where);
        }

        public async Task<List<T>> PageAllAsync(PageRequest? pageRequest, IBaseSpecifications<T>? baseSpecifications)
        {
            return await _repository.PageAllAsync(pageRequest, baseSpecifications);
        }

        public async Task<decimal> CountAllAsync()
        {
            return await _repository.CountAllAsync();
        }

        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }
    }
}
