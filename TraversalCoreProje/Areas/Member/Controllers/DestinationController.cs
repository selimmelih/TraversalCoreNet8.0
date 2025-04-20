using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private readonly DestinationManager _destinationManager;

        public DestinationController(IDestinationDal destinationDal)
        {
            _destinationManager = new DestinationManager(destinationDal);
        }

        public IActionResult Index()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }

        public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = _destinationManager.TGetList().AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(x => x.City.Contains(searchString));
            }

            return View(values.ToList());
        }
    }
}
