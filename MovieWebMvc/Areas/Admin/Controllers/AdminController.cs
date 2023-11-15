using BusinessLayer.Abstract;
using EntityLayer;
using EntityLayer.RequestParameter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieWebMvc.Models;
using System.Data;
using System.Security.Claims;

namespace MovieWebMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IServiceManager _service;
        private readonly ICommentService _commentService;
        public AdminController(IServiceManager service, UserManager<ApplicationUser> userManager, ICommentService commentService)
        {
            _service = service;
            _userManager = userManager;
            _commentService = commentService;
        }
        public async Task<IActionResult> Index(MovieParameter mp)
        {
            var movie = await _service.MovieService.GetAllMoviesAsync(mp, false);
            var pagination = new Pagination()
            {
                CurrentPage = mp.PageNumber,
                PageSize = mp.PageSize,
                TotalMovie = _service.MovieService.GetMovieDetailAsync(mp).Result.Count()
            };
            return View(new MovieListVM()
            {
                Movies = movie.movies,
                Pagination = pagination
            });
        }
        public  IActionResult CreateMovie()
        {
            ViewBag.Genre =  SelectListForGenre();
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMovie([FromForm]MovieDto movieDto,IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", formFile.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                movieDto.ImageUrl = String.Concat("/images/", formFile.FileName);
                _service.MovieService.AddMovieAsync(movieDto);
                TempData["success"] = $"{movieDto.Moviename} has been created.";
                return RedirectToAction("Index");
            }
            return View();
        }
        private SelectList SelectListForGenre()
        {
            return new SelectList ( _service.GenreService.GetAllGenres(false), "GenreId", "MovieGenre", "2");
        }
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Genre = SelectListForGenre();
            var entity = await _service.MovieService.GetMovieAsync(id, false);
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] MovieDto movieDto,IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", formFile.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                movieDto.ImageUrl = String.Concat("/images/", formFile.FileName);
                 _service.MovieService.UpdateMovieAsync(movieDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteMovie([FromRoute(Name = "id")] int id)
        {
            _service.MovieService.DeleteMovieAsync(id,false);
            TempData["danger"] = "The product has been removed.";
            return RedirectToAction("Index");
        }

    }
}
