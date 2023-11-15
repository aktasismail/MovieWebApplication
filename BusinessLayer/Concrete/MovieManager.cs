using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using EntityLayer.RequestParameter;

namespace BusinessLayer.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public MovieManager(IRepositoryManager repositoryManager,
         IMapper mapper)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task AddMovieAsync(MovieDto movieDto)
        {
            Movies movies = _mapper.Map<Movies>(movieDto);
            _repositoryManager.movieRepository.Add(movies);
              _repositoryManager.SaveChanges();
        }

        public async Task DeleteMovieAsync(int id, bool trackChanges)
        {
            var movies = await _repositoryManager.movieRepository.GetMovie(id, false);
            if (movies is not null)
            {
                _repositoryManager.movieRepository.DeleteMovie(movies);
                 _repositoryManager.SaveChanges();
            } 
        }
        public async Task<(IEnumerable<MovieDto> movies,MetaData MetaData)> GetAllMoviesAsync(MovieParameter movieParameter, bool trackchages)
        {
            var movie = await _repositoryManager.movieRepository
                .GetAllMovies(movieParameter, trackchages);
            var moviess = _mapper.Map<IEnumerable<MovieDto>>(movie);
            return (moviess, movie.MetaData);
        }
        public async Task<MovieDto> GetMovieAsync(int id, bool trackchannges)
        {
            var movies = await _repositoryManager.movieRepository.GetMovie(id, false);
            if (movies is null)
                throw new Exception("Filmi bulamıyorum!");
            return _mapper.Map<MovieDto>(movies);
        }
        public async Task<IEnumerable<MovieDto>> GetMovieDetailAsync(MovieParameter mp)
        {
            var movies = await _repositoryManager.movieRepository.GetMovieDetails(mp);
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
        public async Task<IEnumerable<MovieDto>> GetMovieWithGenreIdAsync(MovieParameter mp)
        {
            var movies = await _repositoryManager.movieRepository.GetMovieDetails(mp);
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
        public async Task<IEnumerable<MovieDto>> MostExpensive()
        {
           var movie = await _repositoryManager.movieRepository.MostExpensive();
           return _mapper.Map<IEnumerable<MovieDto>>(movie);
        }
        public async Task<IEnumerable<MovieDto>> MostRecent()
        {
            var movie = await _repositoryManager.movieRepository.MostRecent();
            return _mapper.Map<IEnumerable<MovieDto>>(movie);
        }
        public async Task UpdateMovieAsync(MovieDto movieDto)
        {
            var movie = _mapper.Map<Movies>(movieDto);
            _repositoryManager.movieRepository.UpdateMovie(movie);
             _repositoryManager.SaveChanges();
        }

    }
}
