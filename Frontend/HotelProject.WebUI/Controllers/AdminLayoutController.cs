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
        public PartialViewResult HeaderPartial()
        {
           


            return PartialView();

          /*  var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync("http://localhost:26382/api/Room/First3Rooms");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata2 = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFirs3MessageDto>>(jsondata);
                return PartialView(values);
            }
            return PartialView(new List<ResultFirs3MessageDto>());*/

            
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
