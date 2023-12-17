using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CarPark.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _stringLocalizer;

        public UserController(IStringLocalizer<UserController> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
        public IActionResult Index()
        {
            var nameSurnameValue = _stringLocalizer["NameSurname"];
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserCreateRequestModel request)
        {
            return View(request);
        }
    }
}
