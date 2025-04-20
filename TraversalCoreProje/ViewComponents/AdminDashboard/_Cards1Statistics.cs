using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _Cards1Statistics : ViewComponent
    {
        private readonly Context _context;

        public _Cards1Statistics(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Destinations.Count();
            ViewBag.v2 = _context.Users.Count();

            return View();
        }
    }
}
