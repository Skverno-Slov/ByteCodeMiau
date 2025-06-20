using DatabaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiServices;

namespace AdvisorApp.Pages
{
    public class HotelsModel(EntertainmentService service) : PageModel
    {
        private readonly EntertainmentService _service = service;
        [BindProperty]
        public IEnumerable<Entertainment> Entertainments { get; set; }
        public async Task<IActionResult> OnGetAsync(string type)
        {
            Entertainments = await _service.GetEntertainmentsAsyncByType(type);
            return Page();
        }
    }
}
