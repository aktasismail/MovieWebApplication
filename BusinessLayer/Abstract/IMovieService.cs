using EntityLayer;
using EntityLayer.RequestParameter;

namespace BusinessLayer.Abstract
{
    public interface IMovieService
    {
        Task<(IEnumerable<MovieDto> movies, MetaData MetaData)> GetAllMoviesAsync(MovieParameter movieParameter,bool trackchages);
        Task<MovieDto> GetMovieAsync(int id, bool trackchannges);
        Task<IEnumerable<MovieDto>> GetMovieDetailAsync(MovieParameter mp);
        Task<IEnumerable<MovieDto>> GetMovieWithGenreIdAsync(MovieParameter mp);
        Task AddMovieAsync(MovieDto movieDto);
        Task UpdateMovieAsync(MovieDto movieDto);
        Task DeleteMovieAsync(int id, bool trackchannges);
        Task<IEnumerable<MovieDto>> MostExpensive();
        Task<IEnumerable<MovieDto>> MostRecent();
        
    }
}
