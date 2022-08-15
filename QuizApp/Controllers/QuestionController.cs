using Microsoft.AspNetCore.Mvc;
using QuizApp.Contexts;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {                 
            return View(MockDbContext.Questions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Question model)
        {
            int questionId = new Random().Next();

            var optionA = new Option
            {
                Id = new Random().Next(),
                QuestionId = questionId,
                Name = model.OptionA.Name,
                CreatedAt = DateTimeOffset.UtcNow
            };

            var optionB = new Option
            {
                Id = new Random().Next(),
                QuestionId = questionId,
                Name = model.OptionA.Name,
                CreatedAt = DateTimeOffset.UtcNow
            };

            var optionC = new Option
            {
                Id = new Random().Next(),
                QuestionId = questionId,
                Name = model.OptionA.Name,
                CreatedAt = DateTimeOffset.UtcNow
            };

            var optionD = new Option
            {
                Id = new Random().Next(),
                QuestionId = questionId,
                Name = model.OptionA.Name,
                CreatedAt = DateTimeOffset.UtcNow
            };

            var question = new Question
            {
                Id = questionId,
                Name = model.Name,
                OptionA = optionA,
                OptionB = optionB,
                OptionC = optionC,
                OptionD = optionD,
                CreatedAt = DateTimeOffset.UtcNow
            };

            MockDbContext.Questions.Add(question);

            return RedirectToAction("Index");
        }
    }
}
