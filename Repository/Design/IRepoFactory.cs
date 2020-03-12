namespace Repository.Design
{
    public interface IRepoFactory
    {
        IRepo<T> Repo<T>() where T : class;
    }
}
