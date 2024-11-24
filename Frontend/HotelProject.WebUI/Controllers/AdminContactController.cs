using HotelProject.WebUI.Models.Mail;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;


namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Gelengidensay()
        {

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:26382/api/Contact/GetContactCount");

            
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:26382/api/SendMessage/GetSendMessageCount");

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:26382/api/Contact/İmportantMessageCount");


            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();


            ViewBag.ContactCount = jsondata2;
            ViewBag.SendMessageCount = jsondata3;
            ViewBag.İmportantMessageCount = jsondata4;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Contact");

            await Gelengidensay();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsondata);

                return View(values);
            }


            return View();
        }

        public async Task<IActionResult> importantbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Contact");

            await Gelengidensay();

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<importantMessageDto>>(jsondata);

                return View(values);
            }


            return View();
        }

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/SendMessage");

            await Gelengidensay(); // fonksiyon olarak kullandım çalıştı


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResulStendBoxDto>>(jsondata);

                return View(values);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> AddSendMessage()
        {
            await Gelengidensay();
            return View();
        }



        [HttpPost]

        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("HotelierAdmin", "berkanburakturgut@gmail.com");
            mimeMessage.From.Add(mailboxAddress); // mesaj kimden 

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createSendMessageDto.ReciverMail);
            mimeMessage.To.Add(mailboxAddressTo); // mesaj kime 

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createSendMessageDto.Title; // mesajın içerik ne 
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createSendMessageDto.Content;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false); // 587 port numarası , ssl gereksin mi = fasle istersen true yaparsın
            client.Authenticate("berkanburakturgut@gmail.com", "fwsdhhdhrzzhgqmq");
            client.Send(mimeMessage);
            client.Disconnect(true);


            createSendMessageDto.SenderMail = "admin@gmail.com";
            createSendMessageDto.SenderName = "admin";
            createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());



            var client2 = _httpClientFactory.CreateClient();
            var jstondata = JsonConvert.SerializeObject(createSendMessageDto);

            StringContent StringContent = new StringContent(jstondata, Encoding.UTF8, "application/json");
            var responseMessage = await client2.PostAsync("http://localhost:26382/api/SendMessage", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();




        }



        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetailsSendBox(int id)
        {
            await Gelengidensay();
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/SendMessage/{id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsondata);
                return View(values);
            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            await Gelengidensay();
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Contact/{id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsondata);
                return View(values);
            }
            return View();

        }


        public async Task<IActionResult> İmportantContact(int id)
        {
            var client = _httpClientFactory.CreateClient();


            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Contact/importantContact?id={id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageDetailsByInbox", "AdminContact", new { id = id });
            }
            return View();



        }



    }
}
