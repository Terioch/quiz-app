using QuizApp.Contexts;
using QuizApp.Models;

namespace QuizApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Quizzes = new QuizRepository(db);
            Questions = new QuestionRepository(db);
            Options = new OptionRepository(db);
        }

        public IRepository<Quiz> Quizzes { get; set; }

        public IRepository<Question> Questions { get; private set; }

        public IRepository<Option> Options { get; private set; }

        public int Complete()
        {
            return _db.SaveChanges();
        }
    }
}
