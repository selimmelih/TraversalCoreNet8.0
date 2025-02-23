using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManager guide = new GuideManager(new EfGuideDal());

        public IActionResult Index()
        {
            var values = guide.TGetList();
            return View(values);
        }
    }
}
