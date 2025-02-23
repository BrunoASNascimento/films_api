using films_api.Models;
using Microsoft.EntityFrameworkCore;

namespace films_api.Data;

public class FilmContext : DbContext
{
    public FilmContext(DbContextOptions<FilmContext> options) : base(options)
    {
       
    }

    public DbSet<Film> Films { get; set; }
}
