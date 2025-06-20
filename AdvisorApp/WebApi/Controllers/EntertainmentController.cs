using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntertainmentController(EntertainmentRepository repository) : ControllerBase
    {
        private readonly EntertainmentRepository _repository = repository;
        // GET: api/<GamesController>
        [HttpGet]
        public IActionResult Get()
            => Ok(_repository.GetAll());

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
            => Ok(_repository.GetById(id));

        // POST api/<GamesController>
        [HttpPost]
        public IActionResult Post([FromBody] Entertainment entertainment)
        {
            _repository.Create(entertainment);
            return NoContent();
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entertainment entertainment)
        {
            if (id != entertainment.EntertainmentId)
                return NotFound();

            _repository.Update(entertainment);
            return NoContent();
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
