﻿using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]//yönlendirmeyi yaptık calisti güzel bu kod
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);

                await p.Image.CopyToAsync(stream);
                user.ImageUrl = "/userimages/"+imagename;

            }
            user.Name = p.name;
            user.Surname = p.surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                // Kullanıcı bilgilerini güncelledikten sonra tekrar ViewData'ya aktarabiliriz
                ViewData["UserName"] = user.Name + " " + user.Surname;
                ViewData["UserImageUrl"] = user.ImageUrl;

                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
