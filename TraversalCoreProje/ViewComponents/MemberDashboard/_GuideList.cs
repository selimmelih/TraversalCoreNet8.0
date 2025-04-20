using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        private readonly GuideManager _guideManager;

        public _GuideList(IGuideDal guideDal)
        {
            _guideManager = new GuideManager(guideDal);
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideManager.TGetList();
            return View(values);
        }
    }
}
