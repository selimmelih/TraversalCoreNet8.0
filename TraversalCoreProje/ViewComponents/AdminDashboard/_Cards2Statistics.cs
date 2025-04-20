using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _Cards2Statistics : ViewComponent
    {
        private readonly Context _context;

        public _Cards2Statistics(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
