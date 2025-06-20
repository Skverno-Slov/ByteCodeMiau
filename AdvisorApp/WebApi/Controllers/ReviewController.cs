using DatabaseLibrary.Models;
using DatabaseLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(ReviewRepository repository) : ControllerBase
    {
        private readonly ReviewRepository _repository = repository;
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
        public IActionResult Post([FromBody] Review review)
        {
            _repository.Create(review);
            return NoContent();
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
        {
            if (id != review.EntertainmentId)
                return NotFound();

            _repository.Update(review);
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
