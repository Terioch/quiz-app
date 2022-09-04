using QuizApp.Contexts;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class QuizRepository : Repository<Quiz>, IRepository<Quiz>
    {
        public QuizRepository(ApplicationDbContext db) : base(db)
        {

        }


    }
}
