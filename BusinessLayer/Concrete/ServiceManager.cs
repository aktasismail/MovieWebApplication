using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMovieService> _movieService;
        private readonly Lazy<IGenreService> _genreService;
        private readonly ICommentService _commentService;
        public ServiceManager(IRepositoryManager repositoryManager,IGenreService genreService, IMapper mapper, ICommentService commentService)
        {
            _movieService = new Lazy<IMovieService>(()
                => new MovieManager(repositoryManager, mapper));
            _genreService = new Lazy<IGenreService>(()
                => new GenreManager(repositoryManager));
            _commentService = commentService;
        }
        public IMovieService MovieService => _movieService.Value;

        public IGenreService GenreService => _genreService.Value;
        public ICommentService CommentService => _commentService;
    }
}
