using QuizApp.Contexts;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private readonly ApplicationDbContext _db;

        public QuestionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Question> Get()
        {
            return _db.Questions;
        }

        public Question Get(int id)
        {
            return _db.Questions.Find(id);
        }

        public void Add(Question entity)
        {
            _db.Questions.Add(entity);            
        }        

        public void Delete(Question entity)
        {
            _db.Questions.Remove(entity);
        }
    }
}
