using Microsoft.EntityFrameworkCore;
using QuizApp.Contexts;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class QuestionRepository : Repository<Question>, IRepository<Question>
    {
        private readonly ApplicationDbContext _db;

        public QuestionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public override IEnumerable<Question> Get()
        {
            return _db.Questions.Include(x => x.Options);
        }       
    }
}
