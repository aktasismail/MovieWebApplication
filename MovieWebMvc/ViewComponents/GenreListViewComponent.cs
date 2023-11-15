using BusinessLayer.Abstract;
using DataAccessLayer;
using EntityLayer.RequestParameter;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebMvc.ViewComponents
{
    public class GenreListViewComponent:ViewComponent
    {
        private readonly MovieDbContext _db;
        public GenreListViewComponent(MovieDbContext db)
        {
            _db=db;
        }
        public async Task<IViewComponentResult> InvokeAsync(MovieParameter p)
        {
            var genres = _db.Genres.ToList();
            return View(genres);
        }
    }
}
