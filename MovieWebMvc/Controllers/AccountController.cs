using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieWebMvc.Models;

namespace MovieWebMvc.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl="/")
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl,
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user,loginModel.Password,false,false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Giriş Başarısız", "Kullanıcı ve şifre yanlış");
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm]RegisterDto registerDto)
        {
            var entity = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
            var user = await _userManager.CreateAsync(entity,registerDto.Password);
            
            if (user.Succeeded)
            {
                var addrole = await _userManager.AddToRoleAsync(entity, "User");
                if (addrole.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }

    }
}
