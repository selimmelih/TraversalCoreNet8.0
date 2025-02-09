using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            FluentValidation.Results.ValidationResult result = validationRules.Validate(guide);

            if (result.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToTrue(int id)
        {
            var values = _guideService.TGetByID(id);

            return RedirectToAction("Index");

        }
        public IActionResult ChangeToFalse(int id)
        {
            var values = _guideService.TGetByID(id);

            return RedirectToAction("Index");

        }
    }
}
