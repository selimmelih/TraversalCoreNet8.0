using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        private readonly DestinationManager _destinationManager;

        public _PopularDestinations(IDestinationDal destinationDal)
        {
            _destinationManager = new DestinationManager(destinationDal);
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationManager.TGetList();
            return View(values);
        }
    }
}
