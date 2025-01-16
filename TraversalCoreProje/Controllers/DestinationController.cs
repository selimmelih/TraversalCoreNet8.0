using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        public IActionResult DestinationDetails(int id)
        {

            // Veritabanında DestinationID'nin var olup olmadığını kontrol et
            var destinationExists = destinationManager?.TGetByID(id);


            // Eğer DestinationID geçerli değilse, hata mesajı göster
            if (destinationExists == null)
            {
                return NotFound("Böyle Bir linke sahip rotamız yoktur. Lütfen tekrar deneyin.");
            }
            ViewBag.i = id;
            var values = destinationManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination dest)
        {
            return View();
        }
    }
}
