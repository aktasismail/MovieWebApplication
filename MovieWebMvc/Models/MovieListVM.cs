using EntityLayer;

namespace MovieWebMvc.Models
{
    public class MovieListVM
    {
        public IEnumerable<MovieDto> Movies { get; set; } = Enumerable.Empty<MovieDto>();
        public Pagination Pagination { get; set; } = new();
        public Comments Comments { get; set; }
    }
}
