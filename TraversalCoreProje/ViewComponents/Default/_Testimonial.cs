using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        private readonly TestimonialManager _testimonialManager;

        public _Testimonial(ITestimonialDal testimonialDal)
        {
            _testimonialManager = new TestimonialManager(testimonialDal);
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialManager.TGetList();
            return View(values);
        }
    }
}
