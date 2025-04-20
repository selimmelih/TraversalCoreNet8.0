using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly GuideManager _guideManager;

        public GuideController(IGuideDal guideDal)
        {
            _guideManager = new GuideManager(guideDal);
        }

        public IActionResult Index()
        {
            var values = _guideManager.TGetList();
            return View(values);
        }
    }
}
