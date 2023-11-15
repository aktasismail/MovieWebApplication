using EntityLayer;
using EntityLayer.RequestParameter;

namespace DataAccessLayer.Abstract
{
    public interface IMovieRepository:IRepository<Movies>
    {
        Task<PagedList<Movies>> GetAllMovies(MovieParameter movieParameter,bool trackchages);
        Task<IEnumerable<Movies>> GetMovieDetails(MovieParameter mp);
        Task<Movies> GetMovie(int id,bool trackchages);
        Task<IEnumerable<Movies>> MostExpensive();
        Task<IEnumerable<Movies>> MostRecent();
        void CreateMovie(Movies movie);
        void UpdateMovie(Movies movies);
        void DeleteMovie(Movies movies);
        
    }
}
