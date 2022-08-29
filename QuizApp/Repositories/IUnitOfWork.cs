using QuizApp.Models;

namespace QuizApp.Repositories
{
    public interface IUnitOfWork
    {
        public IRepository<Question> Questions { get; }

        public IRepository<Option> Options { get; }

        int Complete();
    }
}
