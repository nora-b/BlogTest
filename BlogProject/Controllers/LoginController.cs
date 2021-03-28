using BlogProject.IRepositories;
using BlogProject.Models;
using BlogProject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class LoginController : Controller
    {
        //private readonly SignInManager<IdentityUser> signInManager;
        private readonly IUserRepository _userRepository;

        //SignInManager<IdentityUser> signInManager,
        public LoginController(IUserRepository userRepository)
        {
            //this.signInManager = signInManager;
            this._userRepository = userRepository;

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                //user = blogDBContext.Users.Single(u => u.Username.Equals(model.Username));
                if (user != null)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

                //var result = await signInManager.PasswordSignInAsync(
                //    model.Username, model.Password, model.RememberMe, false);

                //if (result.Succeeded)
                //{
                //    return RedirectToAction("index", "home");
                //}

            }


            //var db = blogDBContext;
            //User user = null;
            //user = db.Users.Single(u => u.Username.Equals(model.Username));
            //if (user != null)
            //{
            //    var result = signInManager.PasswordSignInAsync(user.Username, model.Password, model.RememberMe, false);
            //    if (!result.IsFaulted)
            //    {
            //        return RedirectToAction("index", "home");
            //    }

            return View(model);

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            bool userExists;
            if (ModelState.IsValid)
            {
             userExists = _userRepository.GetUserByUsername(model.Username);
                if (userExists)
                {
                    ModelState.AddModelError(string.Empty, "This user exists");
                }else
                {
                    _userRepository.SaveUser(model);
                    return RedirectToAction("index", "home");
                }
            }
            return View(model);

        }
    }
}
