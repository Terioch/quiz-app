using Microsoft.AspNetCore.Mvc;
using QuizApp.Contexts;
using QuizApp.Models;
using System.Diagnostics;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;        
        private static int _score;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;            
        }

        public IActionResult Index()
        {
            var question = MockDbContext.Questions.FirstOrDefault();

            ViewBag.QuestionId = question == null ? -1 : question.Id;

            return View();
        }

        public IActionResult Question(int id, int selectedOptionId, bool isStart = false)
        {
            if (!MockDbContext.Questions.Any())
            {
                return RedirectToAction("Create");
            }

            if (isStart)
            {
                return View(MockDbContext.Questions.First());
            }

            var question = MockDbContext.Questions.FirstOrDefault(x => x.Id == id);

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
            var index = MockDbContext.Questions.IndexOf(question);           

            if (index == MockDbContext.Questions.Count - 1)
            {                
                return View("Result", _score);
            }

            var nextQuestion = MockDbContext.Questions.ElementAt(index + 1);

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