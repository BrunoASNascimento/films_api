using Microsoft.AspNetCore.Mvc;
using films_api.Models;

namespace films_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private static List<Film> films = new List<Film>();

        [HttpPost]
        public void AddFilm([FromBody] Film film)
        {

            films.Add(film);
            Console.WriteLine("Film added: " + film.Title);

        }
    }
}
