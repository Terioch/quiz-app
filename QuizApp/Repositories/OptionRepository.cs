using QuizApp.Contexts;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class OptionRepository : IRepository<Option>
    {
        private readonly ApplicationDbContext _db;

        public OptionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Option> Get()
        {
            return _db.Options;
        }

        public Option Get(int id)
        {
            return _db.Options.Find(id);
        }

        public void Add(Option entity)
        {
            _db.Options.Add(entity);
        }

        public void Delete(Option entity)
        {
            _db.Options.Remove(entity);
        }
    }
}
