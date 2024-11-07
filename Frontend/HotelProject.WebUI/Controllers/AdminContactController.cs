using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsondata);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Sendbox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResulStendBoxDto>>(jsondata);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        public IActionResult AddSendMessage()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.SenderMail = "admin@gmail.com";
            createSendMessageDto.SenderName = "admin";
            createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
          
            var client = _httpClientFactory.CreateClient();
            var jstondata = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent StringContent = new StringContent(jstondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:26382/api/SendMessage", StringContent);
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

        public IActionResult MessageDetails(int id)
        {
            id = 0;
            return View();

            // Ders 111 de kaldım. Gelen mesaj detayları

        }
    }
}
