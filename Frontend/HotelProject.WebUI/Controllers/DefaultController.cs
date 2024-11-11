using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();

        }

        [HttpGet]

        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]

        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto createSubscribeDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jstondata = JsonConvert.SerializeObject(createSubscribeDto);
            StringContent StringContent = new StringContent(jstondata, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:26382/api/Subscribe", StringContent);

            return RedirectToAction("Index", "Default");


        }

    }
}
