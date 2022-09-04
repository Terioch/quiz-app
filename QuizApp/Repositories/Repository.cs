using QuizApp.Contexts;

namespace QuizApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual IEnumerable<T> Get()
        {
            return _db.Set<T>();            
        }

        public virtual T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public virtual void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }        
    }
}
