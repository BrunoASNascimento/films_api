using System.ComponentModel.DataAnnotations;

namespace films_api.Models
{
    public class Film
    {
        [Required(ErrorMessage ="The Title of the film is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Genre of the film is required.")]
        [MaxLength(50, ErrorMessage = "The length of Genre cannot exceed 50 characters.")]
        public string Genre { get; set; }
        [Required]
        [Range(60,600, ErrorMessage ="The duration needs to be between 60 and 600 minutes.")]
        public int Duration { get; set; }
    }
}
