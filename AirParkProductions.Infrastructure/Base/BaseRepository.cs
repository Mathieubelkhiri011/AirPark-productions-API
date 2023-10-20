using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using AirParkProductions.Domain.Base;
using AirParkProductions.Domain.Enums;
using AirParkProductions.Domain.Exceptions;
using AirParkProductions.Domain.Request;
using AirParkProductions.Infrastructure.Databases;
using AirParkProductions.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace AirParkProductions.Infrastructure.Base
{
    public class BaseRepository<T, TContext> : IBaseRepository<T>
        where T : BaseEntity
        where TContext : AirParkProductionsDbContext
    {
        protected readonly TContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;
        protected readonly CancellationToken _cancellationToken;

        public BaseRepository(TContext context, IHttpContextAccessor httpContext)
        {
            _dbContext = context;
            _httpContext = httpContext;
            _cancellationToken = httpContext.HttpContext.RequestAborted;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetBy(Expression<Func<T, bool>> where, IBaseSpecifications<T> baseSpecifications)
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                    .Where(where)
                    .AsQueryable(), baseSpecifications)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(_cancellationToken);
        }

        public async Task<T> GetBy(IBaseSpecifications<T> baseSpecifications)
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                    .AsQueryable(), baseSpecifications)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(_cancellationToken);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await GetAllQueryable().ToList(_cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where)
        {
            return await GetAllQueryable(where).ToList(_cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(IBaseSpecifications<T>? baseSpecifications)
        {
            return await GetAllQueryable(baseSpecifications).ToList(_cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(string query, IBaseSpecifications<T>? baseSpecifications)
        {
            try
            {
                return await GetAllQueryable(query, baseSpecifications).ToList(_cancellationToken);
            }
            catch (AirParkProductionsException ex)
            {
                throw AirParkProductionsException.Format(ex, StatusCodes.Status500InternalServerError, AirParkProductionsErrorEnum.AirParkProductions_500_INTERNAL_SERVER_ERROR, nameof(T));
            }
        }

        public async Task<List<T>> GetAllAsync(string query, List<MySqlParameter> parameters, IBaseSpecifications<T>? baseSpecifications)
        {
            return await GetAllQueryable(query, parameters, baseSpecifications).ToList(_cancellationToken);
        }

        public async Task<decimal> CountAllAsync(Expression<Func<T, bool>> where)
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                   .AsQueryable(), new BaseSpecifications<T>(where))
                   .AsNoTracking()
                   .CountAsync(_cancellationToken);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync(_cancellationToken);
        }

        public async Task Update(T entity)
        {
            _dbContext.Update(entity);
            await SaveAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await SaveAsync();
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>> where = null)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                    .AsQueryable(), new BaseSpecifications<T>(where))
                    .AsNoTracking();
        }

        public IQueryable<T> GetAllQueryable(IBaseSpecifications<T>? baseSpecifications)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                .AsQueryable(), baseSpecifications)
                .AsNoTracking();
        }

        public IQueryable<T> GetAllQueryable(string query, IBaseSpecifications<T>? baseSpecifications)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                .FromSqlRaw(query), baseSpecifications)
                .AsNoTracking();
        }

        public IQueryable<T> GetAllQueryable(string query, List<MySqlParameter> parameters, IBaseSpecifications<T>? baseSpecifications)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                .FromSqlRaw(query, parameters.ToArray()), baseSpecifications)
                .AsNoTracking();
        }

        public async Task<List<TEntity>> GetAllByQueryable<TEntity>(IQueryable<TEntity> query)
        {
            return await query.ToListAsync();
        }

        public async Task<List<T>> PageAllAsync(PageRequest? pageRequest, IBaseSpecifications<T>? baseSpecifications)
        {
            return await PageAllQueryable(pageRequest, baseSpecifications).ToList(_cancellationToken);
        }

        public IQueryable<T> PageAllQueryable(PageRequest? pageRequest, IBaseSpecifications<T>? baseSpecifications)
        {
            if (pageRequest == null)
            {
                pageRequest = new PageRequest();
            }

            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                .AsQueryable(), baseSpecifications)
                .Pageable(pageRequest)
                .AsNoTracking();
        }

        public async Task<decimal> CountAllAsync()
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                   .AsQueryable(), null)
                   .AsNoTracking()
                   .CountAsync(_cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
        {
            return await SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>()
                   .AsQueryable(), new BaseSpecifications<T>(where))
                   .AsNoTracking()
                   .AnyAsync(_cancellationToken);
        }
    }
}

public static class RepositoryExtension
{
    public static async Task<List<T>> ToList<T>(this IQueryable<T> list, CancellationToken cancellationToken)
    {
        return await list.ToListAsync(cancellationToken);
    }
}
