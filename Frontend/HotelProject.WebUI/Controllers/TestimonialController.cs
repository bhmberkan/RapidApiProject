using HotelProject.WebUI.Models.Testimonial;
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
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMessage = await client.GetAsync("http://localhost:26382/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTestimonial()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jstondata = JsonConvert.SerializeObject(model);
            StringContent StringContent = new StringContent(jstondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:26382/api/Testimonial", StringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.DeleteAsync($"http://localhost:26382/api/Testimonial/{id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }

            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var ResponseMessage = await client.GetAsync($"http://localhost:26382/api/Testimonial/{id}");
            if (ResponseMessage.IsSuccessStatusCode)
            {
                var jsondata = await ResponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialViewModel>(jsondata);
                return View(values);
            }
            return View();



        }

        [HttpPost]

        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var ResponseMessage = await client.PutAsync("http://localhost:26382/api/Testimonial/", stringContent);
            if (ResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();


        } /* burada bir şey var gözümden kaçıyor güncelleme yaptığımda ekleme işlemi yapıyor ancak yapmaması lazım. */ 
    }
}
