using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly DestinationManager _destinationManager;
        private readonly ReservationManager _reservationManager;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(
            IDestinationDal destinationDal,
            IReservationDal reservationDal,
            UserManager<AppUser> userManager)
        {
            _destinationManager = new DestinationManager(destinationDal);
            _reservationManager = new ReservationManager(reservationDal);
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationManager.GetListWithReservationByAccepted(user.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> MyOldReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationManager.GetListWithReservationByPrevious(user.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> MyApprovalReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationManager.GetListWithReservationByWaitApproval(user.Id);
            return View(valuesList);
        }

        public IActionResult NewReservation()
        {
            var values = _destinationManager.TGetList()
                .Select(x => new SelectListItem
                {
                    Text = x.City,
                    Value = x.DestinationID.ToString()
                }).ToList();

            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p.AppUserId = user.Id;
            p.Status = "Onay Bekliyor";
            _reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }

        public IActionResult Deneme()
        {
            return View();
        }
    }
}
