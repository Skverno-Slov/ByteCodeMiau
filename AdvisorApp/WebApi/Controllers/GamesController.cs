using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController(GamesRepository repository) : ControllerBase
    {
        private readonly GamesRepository _repository = repository;
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
        public IActionResult Post([FromBody] Game game)
        {
            _repository.Create(game);
            return NoContent();
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Game game)
        {
            if (id != game.Id)
                return NotFound();

            _repository.Update(game);
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
