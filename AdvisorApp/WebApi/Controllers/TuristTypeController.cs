using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuristTypeController(TuristTypeRepostitory repository) : ControllerBase
    {
        private readonly TuristTypeRepostitory _repository = repository;

        [HttpGet]
        public IActionResult Get()
            => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_repository.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] TuristType turistType)
        {
            _repository.Create(turistType);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TuristType turistType)
        {
            if (id != turistType.TuristTypeId)
                return NotFound();

            _repository.Update(turistType);
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
