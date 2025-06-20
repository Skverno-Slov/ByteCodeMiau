using DatabaseLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiServices;

namespace AdvisorApp.Pages
{
    public class HotelModel(HotelService service) : PageModel
    {
        private readonly HotelService _service = service;
        [BindProperty]
        public Entertainment Entertainment { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Entertainment = await _service.GetGameAsync(id);
            if (Entertainment is null)
                return NotFound();
            return Page();
        }
    }
}
