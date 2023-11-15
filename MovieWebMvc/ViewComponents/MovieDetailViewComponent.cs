using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebMvc.ViewComponents
{
    public class MovieDetailViewComponent: ViewComponent
    {
        private IRepositoryManager _service;
        public MovieDetailViewComponent(IRepositoryManager service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movie = _service.movieRepository.GetAll(false);
            return View(movie.OrderByDescending(x=>x.Year).Take(6));
        }
    }
}
