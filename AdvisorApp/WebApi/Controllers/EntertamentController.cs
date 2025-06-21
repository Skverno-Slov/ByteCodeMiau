using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntertamentController(EntertamentRepository repository) : ControllerBase
    {
        private readonly EntertamentRepository _repository = repository;

        [HttpGet]
        public IActionResult Get()
            => Ok(_repository.GetAll());


        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_repository.GetById(id));


        [HttpPost]
        public IActionResult Post([FromBody] Entertament entertament)
        {
            _repository.Create(entertament);
            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entertament entertainment)
        {
            if (id != entertainment.EntertamentId)
                return NotFound();

            _repository.Update(entertainment);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
