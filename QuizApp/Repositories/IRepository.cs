namespace QuizApp.Repositories
{
    public interface IRepository<T> 
    {
        IEnumerable<T> Get();

        T Get(int id);

        void Add(T entity);

        void Delete(T entity);
    }
}
