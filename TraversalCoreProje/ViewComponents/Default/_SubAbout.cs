using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        private readonly SubAboutManager _subAboutManager;

        public _SubAbout(ISubAboutDal subAboutDal)
        {
            _subAboutManager = new SubAboutManager(subAboutDal);
        }

        public IViewComponentResult Invoke()
        {
            var values = _subAboutManager.TGetList();
            return View(values);
        }
    }
}
