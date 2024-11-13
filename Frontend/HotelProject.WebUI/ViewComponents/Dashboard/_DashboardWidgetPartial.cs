using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/DashboardWidgets/StaffCount");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:26382/api/DashboardWidgets/BookingCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:26382/api/DashboardWidgets/AppUserCount");
            
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:26382/api/DashboardWidgets/RoomCount");

            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
            var jsondata3 = await responseMessage3.Content.ReadAsStringAsync();
            var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();
            //   var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsondata);
            ViewBag.Staffcount = jsondata;
            ViewBag.bookingcount = jsondata2;
            ViewBag.AppUserCount = jsondata3;
            ViewBag.RoomCount = jsondata3;







            return View();
        }
    }
}
