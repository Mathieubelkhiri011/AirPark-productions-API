using MySqlConnector;
using AirParkProductions.Domain.Base;
using AirParkProductions.Domain.Request;
using AirParkProductions.Infrastructure.Base;
using System.Linq.Expressions;

namespace AirParkProductions.Application.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<T> GetBy(Expression<Func<T, bool>> where);
        Task<T> GetBy(IBaseSpecifications<T>? baseSpecifications = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where);
        Task<List<T>> GetAllAsync(IBaseSpecifications<T>? baseSpecifications = null);
        Task<List<T>> GetAllAsync(string query, IBaseSpecifications<T>? baseSpecifications = null);
        Task<List<T>> GetAllAsync(string query, List<MySqlParameter> parameters, IBaseSpecifications<T>? baseSpecifications = null);


        Task<List<T>> PageAllAsync(PageRequest? pageRequest = null, IBaseSpecifications<T>? baseSpecifications = null);

        Task<decimal> CountAllAsync();
        Task<decimal> CountAllAsync(Expression<Func<T, bool>> where);
        Task Update(T entity);
        Task AddAsync(T entity);
    }
}
