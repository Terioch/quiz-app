using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using QuizApp.Repositories;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public QuizController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_unitOfWork.Quizzes.Get());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Quiz model, IFormFile formFile)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
            string completeFilePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Open connection to file system and upload image
            var fileStream = new FileStream(completeFilePath, FileMode.Create);
            formFile.CopyTo(fileStream);
            fileStream.Close();

            var quiz = new Quiz
            {
                Name = model.Name,
                Description = model.Description,
                ImageName = uniqueFileName,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _unitOfWork.Quizzes.Add(quiz);

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var quiz = _unitOfWork.Quizzes.Get(id);
            return View(quiz);
        }

        [HttpPost]
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
