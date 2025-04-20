using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
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
        private readonly DestinationManager _destinationManager;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationDal destinationDal, UserManager<AppUser> userManager)
        {
            _destinationManager = new DestinationManager(destinationDal);
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }

        public async Task<IActionResult> DestinationDetails(int id)
        {
            var destinationExists = _destinationManager.TGetDestinationWithGuide(id);
            ViewBag.destId = id;

            if (destinationExists == null)
            {
                return NotFound("Böyle Bir linke sahip rotamız yoktur. Lütfen tekrar deneyin.");
            }

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NameSurname = values?.Name + " " + values?.Surname;
            ViewBag.userId = values?.Id;

            return View(destinationExists);
        }

        [HttpPost]
        public IActionResult DestinationDetails(Destination dest)
        {
            return View();
        }
    }
}
