using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages
{
    public class SummaryModel : PageModel
    {
        public int TotalCorrectAnswers { get; set; }

        public void OnGet(int totalCorrectAnswers)
        {
            TotalCorrectAnswers = totalCorrectAnswers;
        }
    }
}
