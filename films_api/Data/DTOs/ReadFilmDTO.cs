using System.ComponentModel.DataAnnotations;

namespace films_api.Data.DTOs;

public class ReadFilmDTO
{

    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }

    public DateTime ReadTime { get; set; } = DateTime.Now;
}
