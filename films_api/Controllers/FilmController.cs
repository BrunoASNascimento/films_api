using Microsoft.AspNetCore.Mvc;
using films_api.Models;
using films_api.Data;
using films_api.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace films_api.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;


    public FilmController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddFilm([FromBody] CreateFilmDTO filmDTO)
    {
        Film film = _mapper.Map<Film>(filmDTO);
        _context.Films.Add(film);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFilmById), new { id = film.Id }, film);
    }

    // <summary>
    // Get all films
    // </summary>
    // <param name="skip">Number of films to skip</param>
    // <param name="take">Number of films to take</param>
    // <returns>A list of films</returns>


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IEnumerable<ReadFilmDTO> GetFilms([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _mapper.Map<List<ReadFilmDTO>>(_context.Films.Skip(skip).Take(take));
    }

    [HttpGet("{Id}")]
    public IActionResult GetFilmById(int id)
    {
        var film = _context.Films.FirstOrDefault(f => f.Id == id);
        if (film == null) return NotFound();
        var filmDTO = _mapper.Map<ReadFilmDTO>(film);
        return Ok(filmDTO);

    }



    [HttpPut("{Id}")]
    public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmDTO filmDTO)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();
        _mapper.Map(filmDTO, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{Id}")]
    public IActionResult PartialUpdateFilm(int id, [FromBody] JsonPatchDocument<UpdateFilmDTO> patchDocument)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();

        var filmDTO = _mapper.Map<UpdateFilmDTO>(film);
        patchDocument.ApplyTo(filmDTO, ModelState);

        if (!TryValidateModel(filmDTO)) return ValidationProblem(ModelState);

        _mapper.Map(filmDTO, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult DeleteFilm(int id)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();
        _context.Films.Remove(film);
        _context.SaveChanges();
        return NoContent();
    }
}
