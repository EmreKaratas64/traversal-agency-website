using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OnlineTravel.Models;

namespace OnlineTravel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest req)
        {
            if (ModelState.IsValid)
            {
                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "coreblog@ilkportfolio.com");

                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress(req.Name, req.ReceiverMail);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = req.MailBody;
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = req.Subject;

                SmtpClient client = new SmtpClient();
                client.Connect("webmail.ilkportfolio.com", 587, false);
                client.Authenticate("coreblog@ilkportfolio.com", "cr798*BK");
                client.Send(mimeMessage);
                client.Disconnect(true);
                return RedirectToAction("AdminDashboard", "Dashboard");
            }

            return View(req);

        }
    }
}
