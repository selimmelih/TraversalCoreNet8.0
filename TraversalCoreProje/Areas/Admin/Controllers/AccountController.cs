using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetById(model.SenderID);
            var valueReceiver = _accountService.TGetById(model.ReceiverID);

            // Store the old balances
            var oldSenderBalance = valueSender.Balance;
            var oldReceiverBalance = valueReceiver.Balance;


            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;
            
            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };

            // Pass the old and new balances to the view
            ViewBag.SenderName = valueSender.Name;
            ViewBag.ReceiverName = valueReceiver.Name;
            ViewBag.OldSenderBalance = oldSenderBalance;
            ViewBag.OldReceiverBalance = oldReceiverBalance;
            ViewBag.NewSenderBalance = valueSender.Balance;
            ViewBag.NewReceiverBalance = valueReceiver.Balance;

            _accountService.TMultiUpdate(modifiedAccounts);
            return View();
        }
    }
}
