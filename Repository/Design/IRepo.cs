using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Design
{
    public interface IRepo<T>
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAsync(FilterDefinition<T> filter);
        Task<List<T>> GetAsync(FilterDefinition<T> filter, SortDefinition<T> sort);
        IQueryable<T> GetRandom();
        IQueryable<T> GetRandom(Expression<Func<T, bool>> filter);
        Task<bool> InsertAsync(T item);
        Task InsertAsync(IList<T> items);
    }
}
