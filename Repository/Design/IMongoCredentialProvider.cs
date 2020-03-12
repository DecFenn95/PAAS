namespace Repository.Design
{
    public interface IMongoCredentialProvider
    {
        string getConnectionString();
    }
}
