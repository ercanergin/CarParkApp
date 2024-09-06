using AspNetCore.Identity.MongoDbCore.Models;
using CarPark.Entities.Concrete;
using CarPark.Models.RequestModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.User.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Personel> _userManager;
        private readonly SignInManager<Personel> _signInManager;
        private readonly RoleManager<MongoIdentityRole> _roleManager;

        public AccountController(UserManager<Personel> userManager, SignInManager<Personel> signInManager, RoleManager<MongoIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCreateModel registerCreateModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new Personel
                {
                    UserName = registerCreateModel.UserName,
                    Email = registerCreateModel.Email,
                    PhoneNumber = "085969547"
                };

                var result = await _userManager.CreateAsync(user, registerCreateModel.Password);

                if (result.Succeeded)
                {
                    var role = new MongoIdentityRole
                    {
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    };

                    await _roleManager.CreateAsync(role);

                    await _userManager.AddToRoleAsync(user, "admin");

                    await _signInManager.SignInAsync(user, false);

                    return RedirectToLocal(returnUrl);
                }
            }
            return View(registerCreateModel);
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
    }
}
