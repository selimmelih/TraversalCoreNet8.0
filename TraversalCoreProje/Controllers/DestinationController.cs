using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        public async Task<IActionResult> DestinationDetails(int id)
        {

            // Veritabanında DestinationID'nin var olup olmadığını kontrol et
            var destinationExists = destinationManager?.TGetDestinationWithGuide(id);
            ViewBag.destId = id;
            // Eğer DestinationID geçerli değilse, hata mesajı göster
            if (destinationExists == null)
            {
                return NotFound("Böyle Bir linke sahip rotamız yoktur. Lütfen tekrar deneyin.");
            }
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = values.Name + " " + values.Surname;
            ViewBag.userId = values.Id;

            return View(destinationExists);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination dest)
        {
            return View();
        }
    }
}
