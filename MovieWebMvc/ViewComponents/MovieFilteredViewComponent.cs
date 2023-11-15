using Microsoft.AspNetCore.Mvc;

namespace MovieWebMvc.ViewComponents
{
    public class MovieFilteredViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
