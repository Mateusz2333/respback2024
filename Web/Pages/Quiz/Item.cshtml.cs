using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BackendLab01.Pages.Quiz
{
    public class ItemModel : PageModel
    {
        private readonly IQuizUserService _userService;
        private readonly ILogger<ItemModel> _logger;

        public ItemModel(IQuizUserService userService, ILogger<ItemModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string Question { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<string> Answers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserAnswer { get; set; }

        [BindProperty(SupportsGet = true)]
        public int QuizId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ItemId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int TotalCorrectAnswers { get; set; } 

        public void OnGet(int quizId, int itemId)
        {
            QuizId = quizId;
            ItemId = itemId;
            var quiz = _userService.FindQuizById(quizId);
            var quizItem = quiz?.Items.FirstOrDefault(item => item.Id == itemId);
            if (quizItem != null)
            {
                Question = quizItem.Question;
                Answers = new List<string>(quizItem.IncorrectAnswers);
                Answers.Add(quizItem.CorrectAnswer);
            }
            else
            {
                _logger.LogError("Nie mo¿na znaleŸæ quizu lub pytania o podanym identyfikatorze.");
            }
        }

        public IActionResult OnPost()
        {
            if (UserAnswer == "CorrectAnswer") 
            {
                TotalCorrectAnswers++; 
            }
            return RedirectToPage("Summary", new { totalCorrectAnswers = TotalCorrectAnswers }); 
        }
    }
}
