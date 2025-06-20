using DatabaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiServices;

namespace AdvisorApp.Pages
{
    public class ReviewsModel(ReviewService service) : PageModel
    {
        private readonly ReviewService _service = service;
        [BindProperty]
        public IEnumerable<Review> Reviews { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Reviews = await _service.GetReviewsAsync();
            return Page();
        }
    }
}
