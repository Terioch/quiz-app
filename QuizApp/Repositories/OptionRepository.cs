using QuizApp.Contexts;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class OptionRepository : Repository<Option>, IRepository<Option>
    {
        private readonly ApplicationDbContext _db;

        public OptionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }        
    }
}
