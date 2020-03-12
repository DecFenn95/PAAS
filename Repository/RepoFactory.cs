using MongoDB.Driver;
using Repository.Context;
using Repository.Design;

namespace Repository
{
    public class RepoFactory : IRepoFactory
    {
        private readonly IDBProvider<IMongoDatabase> _databaseProvider;

        public RepoFactory(IDBProvider<IMongoDatabase> databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public IRepo<T> Repo<T>() where T : class
        {
            return new Repository<T>(_databaseProvider);
        }
    }
}
