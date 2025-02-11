using Microsoft.AspNetCore.Mvc;
using films_api.Models;

namespace films_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>();
        private static int id = 0;

        [HttpPost]
        public IActionResult AddFilm([FromBody] Film film)
        {
            film.Id = id++;
            films.Add(film);
            Console.WriteLine("Film added: " + film.Title);
            return CreatedAtAction(nameof(GetFilmById), new { id = film.Id }, film);
        }


        [HttpGet]
        public IEnumerable<Film> GetFilms([FromQuery] int skip =0, [FromQuery] int take=5)
        {
            return films.Skip(skip).Take(take);
        }

        [HttpGet("{Id}")]
        public IActionResult GetFilmById(int id)
        {
            var film =  films.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound();
            return Ok(film);

        }
    }
}
