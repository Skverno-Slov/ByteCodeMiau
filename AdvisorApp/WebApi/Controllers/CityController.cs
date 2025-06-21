using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController(CityRepository repository) : ControllerBase
    {
        private readonly CityRepository _repository = repository;

        [HttpGet]
        public IActionResult Get()
            => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_repository.GetById(id));

        [HttpPost]
        public IActionResult Post([FromBody] City city)
        {
            _repository.Create(city);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] City city)
        {
            if (id != city.CityId)
                return NotFound();

            _repository.Update(city);
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
