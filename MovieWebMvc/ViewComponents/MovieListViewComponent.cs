using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.RequestParameter;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebMvc.ViewComponents
{
    public class MovieListViewComponent:ViewComponent
    {
        private IRepositoryManager _service;
        public MovieListViewComponent(IRepositoryManager service)
        {
            _service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movie =  _service.movieRepository.GetAll(false);
            return View(movie.Take(6));
        }
    }
}
