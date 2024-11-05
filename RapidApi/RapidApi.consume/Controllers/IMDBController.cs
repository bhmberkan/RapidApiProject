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
    public class IMDBController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMoveViewModel> apiMoveViewModels = new List<ApiMoveViewModel>();  
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "f084fd302dmsh15466ef7d1b7ae3p161789jsn4dfc1862121c" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMoveViewModels = JsonConvert.DeserializeObject<List<ApiMoveViewModel>>(body);
                return View(apiMoveViewModels);

            }
            
        }
    }
}
