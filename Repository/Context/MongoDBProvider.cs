using MongoDB.Driver;
using Repository.Design;

namespace Repository.Context
{
    public class MongoDBProvider : IDBProvider<IMongoDatabase>
    {
        private readonly IMongoClient _client;

        public MongoDBProvider(IMongoCredentialProvider mongoCredentialProvider)
        {
            _client = new MongoClient(mongoCredentialProvider.getConnectionString());
        }

        public IMongoDatabase GetDatabase(string dbName)
        {
            return _client.GetDatabase(dbName);
        }
    }
}
