using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> usermanager)
        {
            _signInManager = signInManager;
            _userManager = usermanager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username,loginViewModel.Password,false/*beni hatırla özelliği cookie de tutulsun mu*/,true/*5 defa dan fazla şifreyi yanlış girerse kullanıcıya 5 dk veya neyse engel koyma*/);

            if (result.Succeeded) 
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.Username);
                if (user.EmailConfirmed == true) 
                {
                    return RedirectToAction("Index","MyProfile");
                
                }

            }

            return View(); 
        
        }
    }
}
