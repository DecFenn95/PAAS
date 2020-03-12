using Microsoft.Extensions.Configuration;
using Repository.Design;

namespace Repository
{
    public class MongoLocalHostCredentialProvider : IMongoCredentialProvider
    {
        private readonly IConfiguration _configuration;

        public MongoLocalHostCredentialProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string getConnectionString()
        {
            return _configuration.GetConnectionString("Local");
        }
    }
}
