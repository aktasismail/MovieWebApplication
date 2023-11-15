using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using EntityLayer.RequestParameter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebMvc.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MovieWebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IServiceManager manager, IMapper mapper)
        {
            _logger = logger;
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Mostpopular = await _manager.MovieService.MostExpensive();
            ViewBag.MostRecent = await _manager.MovieService.MostRecent();

            return View(ViewBag);
        }
        public async Task<IActionResult> MovieDetails([FromRoute] int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movie = await _manager.MovieService.GetMovieAsync(id, false);
            var commmetWithAdded = _manager.CommentService.GetComment(id, false);
            var commmet = _manager.CommentService.GetAllComments(false)
                .Where(x => x.MovieId.Equals(id));
            MovieDetailVM movieDetail = new MovieDetailVM()
            {
                Comments = commmetWithAdded,
                Comment = commmet,
                movieDto = movie
            };
            return View(movieDetail);
        }
        public async Task<IActionResult> GetAllMovies(MovieParameter mp)
        {
            var movie = await _manager.MovieService.GetAllMoviesAsync(mp, false);
            var pagination = new Pagination()
            {
                CurrentPage = mp.PageNumber,
                PageSize = mp.PageSize,
                TotalMovie = _manager.MovieService.GetMovieDetailAsync(mp).Result.Count()
            };
            return View(new MovieListVM()
            {
                Movies = movie.movies,
                Pagination = pagination
            });
        }
        public async Task<IActionResult> GetByGenre(MovieParameter p)
        {
            var genres = await _manager.MovieService.GetMovieWithGenreIdAsync(p);
            return View(genres);
        }
        public async Task<IActionResult> CreateComment(Comments comments)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Comments entity = new Comments()
            {
                UserId = userId,
                MovieId = comments.MovieId,
                CommentText = comments.CommentText,
                Tittle = comments.Tittle,
            };
            _manager.CommentService.CreateComment(entity);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> About()
        {
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}