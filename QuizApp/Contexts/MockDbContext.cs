using QuizApp.Models;

namespace QuizApp.Contexts
{
    public class MockDbContext
    {
        public static readonly List<Question> Questions = new List<Question>()
        {
            new Question
            {
                Id = 1,
                Name = "Question",
                OptionA = new Option
                {
                    Id = 1,
                    Name = "option a",
                    IsCorrect = true,
                    CreatedAt = DateTimeOffset.UtcNow,
                },
                OptionB = new Option
                {
                    Id = 2,
                    Name = "option b",
                    CreatedAt = DateTimeOffset.UtcNow,
                },
                OptionC = new Option
                {
                    Id = 3,
                    Name = "option c",
                    CreatedAt = DateTimeOffset.UtcNow,
                },
                OptionD = new Option
                {
                    Id = 4,
                    Name = "option d",
                    CreatedAt = DateTimeOffset.UtcNow,
                },
            },
            new Question
            {
                Id = 2,
                Name = "Question2",
                OptionA = new Option
                {
                    Id = 5,
                    Name = "option a",
                    CreatedAt = DateTimeOffset.UtcNow,
                },
                OptionB = new Option
                {
                    Id = 6,
                    Name = "option b",
                    CreatedAt = DateTimeOffset.UtcNow,
                },
                OptionC = new Option
                {
                    Id = 7,
                    Name = "option c",
                    IsCorrect = true,
                    CreatedAt = DateTimeOffset.UtcNow,
                },
                OptionD = new Option
                {
                    Id = 8,
                    Name = "option d",
                    CreatedAt = DateTimeOffset.UtcNow,
                },
            },
        };
    }
}
