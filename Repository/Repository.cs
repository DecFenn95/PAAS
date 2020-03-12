using EnsureThat;
using MongoDB.Driver;
using Repository.Context;
using Repository.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : BaseRepository<T>, IRepo<T> where T : class
    {
        public Repository(IDBProvider<IMongoDatabase> databaseProvider)
            : base(databaseProvider)
        {
        }

        public virtual IQueryable<T> Get()
        {
            return Collection.AsQueryable();
        }

        public virtual IQueryable<T> GetRandom()
        {
            var rand = new Random();
            var query = Collection.AsQueryable();
            return query.Skip(rand.Next(query.Count())).AsQueryable();
        }

        public virtual IQueryable<T> GetRandom(Expression<Func<T, bool>> filter)
        {
            Ensure.Any.IsNotNull(filter, nameof(filter));
            var rand = new Random();
            var query = Collection.AsQueryable();
            query.Where(filter);
            return query.Skip(rand.Next(query.Count())).AsQueryable();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            Ensure.Any.IsNotNull(filter, nameof(filter));
            return Collection.AsQueryable().Where(filter);
        }

        public virtual async Task<List<T>> GetAsync(FilterDefinition<T> filter, SortDefinition<T> sort)
        {
            Ensure.Any.IsNotNull(filter, nameof(filter));

            var results = await Collection.FindAsync<T>(filter, new FindOptions<T, T>
            {
                Sort = sort
            });

            return await results.ToListAsync();
        }

        public virtual async Task<List<T>> GetAsync(FilterDefinition<T> filter)
        {
            Ensure.Any.IsNotNull(filter, nameof(filter));

            var results = await Collection.FindAsync<T>(filter);
            return await results.ToListAsync();
        }

        public virtual async Task<bool> InsertAsync(T item)
        {
            Ensure.Any.IsNotNull(item, nameof(item));
            await Collection.InsertOneAsync(item);
            return true;
        }

        public virtual async Task InsertAsync(IList<T> items)
        {
            Ensure.Any.IsNotNull(items, nameof(items));
            await Collection.InsertManyAsync(items);
        }
    }
}
