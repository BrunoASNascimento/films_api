using AutoMapper;
using films_api.Data.DTOs;
using films_api.Models;

namespace films_api.Profiles;

public class FilmProfile : Profile
{
    public FilmProfile()
    {
        CreateMap<CreateFilmDTO, Film>();
        CreateMap<UpdateFilmDTO, Film>();
        CreateMap<Film, UpdateFilmDTO>();
        CreateMap<Film, ReadFilmDTO>();
    }
}
