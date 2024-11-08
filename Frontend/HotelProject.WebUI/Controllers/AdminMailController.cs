using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin","berkanburakturgut@gmail.com");
            mimeMessage.From.Add(mailboxAddress); // mesaj kimden 

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.ReciverMail);
            mimeMessage.To.Add(mailboxAddressTo); // mesaj kime 

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body; // mesajın içerik ne 
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); // 587 port numarası , ssl gereksin mi = fasle istersen true yaparsın
            client.Authenticate("berkanburakturgut@gmail.com", "fwsdhhdhrzzhgqmq");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }


    }
}
