using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        //[HttpPost]
        //public IActionResult SignUp()
        //{
        //    return View();
        //}


        public IActionResult SignIn()
        {
            return View();
        }

    }
}
