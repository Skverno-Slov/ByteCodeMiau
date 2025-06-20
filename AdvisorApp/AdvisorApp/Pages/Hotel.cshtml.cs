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
        public Hotel Hotel { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Hotel = await _service.GetGameAsync(id);
            if (Hotel is null)
                return NotFound();
            return Page();
        }
    }
}
