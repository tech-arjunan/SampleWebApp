namespace SampleWebApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        T GetById(int id);
        void Add(T entity);
    }
}
