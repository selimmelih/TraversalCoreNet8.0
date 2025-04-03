using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        private readonly Context _context;

        public _MemberLayoutNavbar(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                // Kullanıcı oturum açmamışsa, boş bir view dönebilirsiniz veya farklı bir işlem yapabilirsiniz.
                return View("Default");
            }

            // Kullanıcıyı veritabanından çekiyoruz.
            var currentUser = _context.Users.FirstOrDefault(m=>m.Id.ToString()==userId);
            if (currentUser == null)
            {
                // Kullanıcı bulunamazsa da aynı şekilde bir fallback view dönebilirsiniz.
                return View("Default");
            }

            ViewData["Name"] = currentUser.Name;
            ViewData["Surname"] = currentUser.Surname;
            ViewData["UserImageUrl"] = currentUser.ImageUrl;

            return View();
        }

    }
}
