using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _AdminFirst3MessagePartial : ViewComponent
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminFirst3MessagePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:26382/api/Contact/GetContactCount");

            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.ContactCount = jsondata2;


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Contact/First3Message");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFirs3MessageDto>>(jsondata);
                return View(values);

            }
            return View();
        }
    }
}
