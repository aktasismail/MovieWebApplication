//using BusinessLayer.Abstract;
//using DataAccessLayer;
//using EntityLayer;
//using EntityLayer.RequestParameter;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;

//namespace MovieWebMvc.ViewComponents
//{
//    public class CommentViewComponents
//    {
//        public ClaimsPrincipal UserClaimsPrincipal { get; }
//        private readonly IServiceManager _db;
//        private readonly UserManager<ApplicationUser> _userManager;
//        public CommentViewComponents(IServiceManager db)
//        {
//            _db = db;
//        }
//        public async Task<IViewComponentResult> InvokeAsync(Comments comments)
//        {
//            _userManager.GetUserId(Request.HttpContext.User);
//            //string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//            Comments entity = new Comments()
//            {
//                UserId = userId,
//                MovieId = comments.MovieId,
//                CommentText = comments.CommentText,
//                Tittle = comments.Tittle,
//            };
//            _db.CommentService.CreateComment(entity);
//            return re("MovieDetails", "Home");
//        }
//    } 
//    }
//}
