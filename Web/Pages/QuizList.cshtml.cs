using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using BackendLab01;




namespace BackendLab01.Pages
{
    public class QuizListModel : PageModel
    {
        private readonly IQuizService _quizService;

        public QuizListModel(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public List<Quiz> Quizzes { get; set; }

        public void OnGet()
        {
            Quizzes = _quizService.GetAllQuizzes();
        }
    }
}
