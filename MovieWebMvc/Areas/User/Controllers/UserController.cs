using BusinessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieWebMvc.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ICommentService _commentService;
        public UserController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IActionResult> MyProfile(string Name)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _commentService.GetAllComments(false).Where(x => x.UserId.Equals(userId));

            return View(user);
        }
        //public async Task<IActionResult> UpdateComment(int id)
        //{
        //    var entity = _commentService.GetComment(id, false);
        //    return View(entity);
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateComment(Comments comments)
        //{
        //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //        var comment = new Comments
        //        {
        //            MovieId=comments.MovieId,
        //            CommentText = comments.CommentText,
        //            UserId = userId,
        //            Tittle = comments.Tittle,

        //        };
        //        _commentService.UpdateComment(comment);

        //        return RedirectToAction(nameof(Index));

        //}
        public IActionResult DeleteComment([FromRoute(Name = "id")] int id)
        {
            var delete = _commentService.GetComment(id, false);
            _commentService.DeleteComment(delete);
            TempData["danger"] = "The product has been removed.";
            return RedirectToAction("Index");
        }
    }
}
