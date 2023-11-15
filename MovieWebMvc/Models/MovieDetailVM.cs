using EntityLayer;

namespace MovieWebMvc.Models
{
    public class MovieDetailVM
    {
        public MovieDto movieDto { get; set; } = new MovieDto();
        public Comments Comments { get; set; }
        public IEnumerable<Comments> Comment { get; set; }
    }
}
