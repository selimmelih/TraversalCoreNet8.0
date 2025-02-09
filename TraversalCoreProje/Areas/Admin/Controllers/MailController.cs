using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/")]
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            //gönderecek kisi bilgileri
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","traversalnetproje@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            //alici kisi bilgileri
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = mailRequest.Body;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //mimeMessage.Body = mailRequest.Body;

            mimeMessage.Subject = mailRequest.Subject;

            //mimeMessage.TextBody = mailRequest.Body;

            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com",587,false);
            client.Authenticate("traversalnetproje@gmail.com", "coeoshgqdufdgwfg");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return RedirectToAction("Index");
        }
    }
}
