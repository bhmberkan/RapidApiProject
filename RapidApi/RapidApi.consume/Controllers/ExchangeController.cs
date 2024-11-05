using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using RapidApi.consume.Models;
using Newtonsoft.Json;

namespace RapidApi.consume.Controllers
{
    public class ExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            //    List<ExchangeViewModel> exchangeViewModels = new List<ExchangeViewModel>(); // ihtiyaç kalmadı

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "f084fd302dmsh15466ef7d1b7ae3p161789jsn4dfc1862121c" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                if (values.exchange_rates !=null)
                {
                    return View(values.exchange_rates.ToList());
                }
                return View();
               
            }

        

        }
    }
}
