using BuildYourBowl.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class ReviewModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Time = DateTime.Now;
            ReviewDatabase.AddReview(new Review(ReviewText, Time));

            ReviewText = null;
        }

        [BindProperty]
        public string? ReviewText { get; set; }

        [BindProperty]
        public DateTime Time { get; set; }

        public IEnumerable<Review> AllReviews => ReviewDatabase.Reviews.OrderByDescending(review => review.Time);
    }
}
