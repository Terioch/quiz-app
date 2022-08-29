using Microsoft.AspNetCore.Mvc;
using QuizApp.Contexts;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
        public IActionResult Create(Question model, int correctOptionIndex)
        {
            var question = new Question
            {                
                Name = model.Name,                
                CreatedAt = DateTimeOffset.UtcNow
            };

            _unitOfWork.Questions.Add(question);

            var options = new List<Option> { model.OptionA, model.OptionB, model.OptionC, model.OptionD };        

            for (int i = 0; i < options.Count; i++)
            {
                options[i] = new Option
                {
                    QuestionId = question.Id,
                    Name = options[i].Name,
                    IsCorrect = i == correctOptionIndex,
                    CreatedAt = DateTimeOffset.UtcNow,
                };

                _unitOfWork.Options.Add(options[i]);
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}
