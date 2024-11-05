using HotelProject.WebUI.Dtos.BookingDto;
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
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsondata);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApprovedRezervation(ApprovedBookingRezervationDto approvedBookingRezervationDto)
        {
            approvedBookingRezervationDto.Status = "Onaylandı";
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(approvedBookingRezervationDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PutAsync("http://localhost:26382/api/bbbb/", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

            // burdaki onaylama kısmına müfredatın en sonunda değineceğiz
           
        }

    }
}
