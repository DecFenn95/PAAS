namespace Repository.Context
{
    public interface IDBProvider<out T>
    {
        T GetDatabase(string dbName);
    }
}
