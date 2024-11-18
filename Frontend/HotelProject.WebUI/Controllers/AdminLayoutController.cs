using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult _AdminLayout()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {

            return PartialView();
        }

        public PartialViewResult PreloaderPartial()
        {

            return PartialView();
        }

        public Task<PartialViewResult> NavHeaderPartial()
        {

            return Task.FromResult(PartialView());
        }
        public async Task<PartialViewResult> HeaderPartial()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Contact/GetContactCount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();

            ViewBag.ContactCount = jsondata;



            /*  var responseMessage2 = await client.GetAsync("http://localhost:26382/api/Contact");
              var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();


              var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsondata2);




              return PartialView(values);*/
            return PartialView();
            
        }

        public PartialViewResult SideBarPartial()
        {

            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {

            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {

            return PartialView();
        }


    }
}
