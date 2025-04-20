using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        private readonly FeatureManager _featureManager;

        public _Feature(IFeatureDal featureDal)
        {
            _featureManager = new FeatureManager(featureDal);
        }

        public IViewComponentResult Invoke()
        {
            // Örnek kullanım, istersen ViewBag ile tekil veri de gönderebilirsin.
            var values = _featureManager.TGetList();
            return View(values);
        }
    }
}
