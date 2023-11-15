using DataAccessLayer.Abstract;
using DataAccessLayer.ExtentionMethod;
using EntityLayer;
using EntityLayer.RequestParameter;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class MovieRepository : RepositoryBase<Movies>, IMovieRepository
    {
        public MovieRepository(MovieDbContext db):base(db)
        {
            
        }
        public async Task<PagedList<Movies>> GetAllMovies(MovieParameter movieParameter, bool trackchages) 
        {
            var movies = await GetAll(trackchages)
                .OrderBy(b => b.MovieId)
                .FilterByRate(movieParameter.MinRate,movieParameter.MaxRate)
                .Search(movieParameter.SearchKey)
                .ToListAsync();
            return PagedList<Movies>.ToPagedList(movies, movieParameter.PageNumber, movieParameter.PageSize);
        }
        public async Task<Movies> GetMovie(int id, bool trackchages)=>
            await FindbyId(x => x.MovieId.Equals(id), trackchages).SingleOrDefaultAsync();

        public async Task<IEnumerable<Movies>> GetMovieDetails(MovieParameter mp)
        {
            var movie = await _db.Movies
            .GetByGenres(mp.GenreId)
            .ToListAsync();
            return movie;
        }
        public void CreateMovie(Movies movie)
        {
            Add(movie);
        }
        public void DeleteMovie(Movies movies)
        {
            Delete(movies);
            
        }
        public void UpdateMovie(Movies movies)
        {
            Update(movies);
        }
        public async Task<IEnumerable<Movies>> MostExpensive()
        {
            var movies =  _db.Movies.OrderByDescending(x => x.MovieId).Skip(4).Take(4).ToList();
            return movies;
        }
        public async Task<IEnumerable<Movies>> MostRecent()
        {
            var movies = _db.Movies.OrderByDescending(x => x.MovieId).Take(4).ToList();
            return movies;
        }
    }
}
