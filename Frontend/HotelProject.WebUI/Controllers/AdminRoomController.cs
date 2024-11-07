using HotelProject.WebUI.Dtos.RomDto;
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
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddRoom()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddRoom(ResultRoomDto resultRoomDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jstondata = JsonConvert.SerializeObject(resultRoomDto);
            StringContent StringContent = new StringContent(jstondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:26382/api/Room", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.DeleteAsync($"http://localhost:26382/api/Room/{id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Room/{id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRoomDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateRoomDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PutAsync("http://localhost:26382/api/Room/", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

