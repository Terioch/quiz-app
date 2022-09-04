using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Quizzes.Get());
        }

        public IActionResult Edit(int id)
        {
            var quiz = _unitOfWork.Quizzes.Get(id);
            return View();
        }

        public IActionResult Edit(Quiz model)
        {
            var quiz = _unitOfWork.Quizzes.Get(model.Id);

            quiz.Name = model.Name;
            quiz.Description = model.Description;

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}
