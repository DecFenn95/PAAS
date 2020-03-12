using EnsureThat;
using MongoDB.Driver;
using Repository.Context;
using System;

namespace Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly IDBProvider<IMongoDatabase> _databaseProvider;
        private readonly Lazy<IMongoCollection<T>> _collectionLocal;

        protected IMongoCollection<T> Collection => _collectionLocal.Value;

        internal BaseRepository(IDBProvider<IMongoDatabase> databaseProvider)
        {
            Ensure.Any.IsNotNull(databaseProvider, nameof(databaseProvider));

            _databaseProvider = databaseProvider;
            _collectionLocal = new Lazy<IMongoCollection<T>>(() => GetCollection(), true);
        }

        private IMongoCollection<T> GetCollection()
        {
            var type = typeof(T);
            return _databaseProvider
                    .GetDatabase(getDataSource())
                    .GetCollection<T>(type.Name);

            string getDataSource()
            {
                return DataSourceName.PAAS.ToString();
            }
        }
    }
}
