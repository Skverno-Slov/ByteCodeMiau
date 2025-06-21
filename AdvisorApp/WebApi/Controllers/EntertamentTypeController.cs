using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntertamentTypeController(EntertamentTypeRepository repository) : ControllerBase
    {
        private readonly EntertamentTypeRepository _repository = repository;

        [HttpGet]
        public IActionResult Get()
            => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_repository.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] EntertamentType entertamentType)
        {
            _repository.Create(entertamentType);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EntertamentType entertamentType)
        {
            if (id != entertamentType.EntertamentTypeId)
                return NotFound();

            _repository.Update(entertamentType);
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
