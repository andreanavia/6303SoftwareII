using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystem.Models;
using MovieReservationSystem.Repositories;

namespace MovieReservationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _repo;

        public MoviesController(IMovieRepository repo)
        {
            _repo = repo;
        }

        // GET: api/movies
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _repo.GetAllAsync();
            return Ok(movies);
        }

        // GET: api/movies/5
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _repo.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _repo.AddAsync(movie);
            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/5
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Title = movie.Title;
            existing.Description = movie.Description;
            existing.Duration = movie.Duration;
            existing.PosterUrl = movie.PosterUrl;

            await _repo.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/movies/5
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _repo.GetByIdAsync(id);
            if (movie == null) return NotFound();

            await _repo.DeleteAsync(movie.Id);
            return NoContent();
        }
    }
}
