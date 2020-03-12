using Microsoft.Extensions.Configuration;
using Repository.Design;

namespace Repository
{
    public class MongoAtlasCredentialProvider : IMongoCredentialProvider
    {
        private readonly IConfiguration _configuration;

        public MongoAtlasCredentialProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string getConnectionString()
        {
            return _configuration.GetConnectionString("Atlas");
        }
    }
}
