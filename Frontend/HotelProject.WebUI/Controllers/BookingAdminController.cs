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




        public async Task<IActionResult> ApprovedRezervation2(int id)
        {
            
            var client = _httpClientFactory.CreateClient();
           
           
            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Booking/BookingAproved?id={id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> CancelRezervation(int id)
        {

            var client = _httpClientFactory.CreateClient();


            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Booking/BookingCancel?id={id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> WaitRezervation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Booking/BookingWait?id={id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Booking/{id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
          
            
                var client = _httpClientFactory.CreateClient();
                var jsondata = JsonConvert.SerializeObject(updateBookingDto);
                StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
                var ResponseMessage = await client.PutAsync("http://localhost:26382/api/Booking/UpdateBooking", stringContent);
                if (ResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            
           


        }



       

    }
}
