using Microsoft.AspNetCore.Mvc;
using QuizApp.Contexts;
using QuizApp.Models;
using QuizApp.Repositories;
using System.Diagnostics;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        private static int _score;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {          
            var question = _unitOfWork.Questions.Get().FirstOrDefault();

            ViewBag.QuestionId = question == null ? -1 : question.Id;

            return View();
        }

        public IActionResult Question(int id, int selectedOptionId, bool isStart = false)
        {
            var questions = _unitOfWork.Questions.Get().ToList();

            if (!questions.Any())
            {
                return RedirectToAction("Create");
            }

            if (isStart)
            {
                return View(questions.First());
            }

            var question = questions.FirstOrDefault(x => x.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            // Update score based on selection
            var selectedOption = question.Options.FirstOrDefault(x => x.Id == selectedOptionId);

            if (selectedOption.IsCorrect)
            {
                _score++;
            }           

            // Pagination
            int index = questions.IndexOf(question);

            if (index == questions.Count - 1)
            {                
                return View("Result", _score);
            }

            var nextQuestion = questions.ElementAt(index + 1);           

            return View(nextQuestion);
        }        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}