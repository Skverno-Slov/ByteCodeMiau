using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController(HotelRepository repository) : ControllerBase
    {
        private readonly HotelRepository _repository = repository;
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
        public IActionResult Post([FromBody] Hotel hotel)
        {
            _repository.Create(hotel);
            return NoContent();
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Hotel hotel)
        {
            if (id != hotel.HotelId)
                return NotFound();

            _repository.Update(hotel);
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
