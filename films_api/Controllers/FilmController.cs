﻿using Microsoft.AspNetCore.Mvc;
using films_api.Models;
using films_api.Data;
using films_api.Data.DTOs;
using AutoMapper;

namespace films_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private FilmContext _context;
        private IMapper _mapper;


        public FilmController(FilmContext context,IMapper mapper)
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


        [HttpGet]
        public IEnumerable<Film> GetFilms([FromQuery] int skip =0, [FromQuery] int take=5)
        {
            return _context.Films.Skip(skip).Take(take);
        }

        [HttpGet("{Id}")]
        public IActionResult GetFilmById(int id)
        {
            var film =  _context.Films.FirstOrDefault(f => f.Id == id);
            if (film == null) return NotFound();
            return Ok(film);

        }
    }
}
