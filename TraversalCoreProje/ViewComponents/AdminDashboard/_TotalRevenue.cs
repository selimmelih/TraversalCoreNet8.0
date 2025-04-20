using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.AdminDashboard
{
    public class _TotalRevenue:ViewComponent
    {
        private readonly Context _context;

        public _TotalRevenue(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
