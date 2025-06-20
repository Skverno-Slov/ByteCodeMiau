using DatabaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiServices;

namespace AdvisorApp.Pages
{
    public class HotelModel(EntertainmentService service) : PageModel
    {
        private readonly EntertainmentService _service = service;
        [BindProperty]
        public Entertainment Entertainment { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Entertainment = await _service.GetEntertainmentsAsync(id);
            if (Entertainment is null)
                return NotFound();
            return Page();
        }
    }
}
