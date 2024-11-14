using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HotelProject.WebUI.Dtos.DashboardDto;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashBoardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // List<ResulInstagramFallowersDto> resulInstagramFallowersDto = new List<ResulInstagramFallowersDto>(); // biz ekledik verileri liste olarak almak için
            // ancak tek veri alacağımız için list yapısı kullanmamıza gerek yok 
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/bhmberkan"),
                Headers =
        {
            { "x-rapidapi-key", "f084fd302dmsh15466ef7d1b7ae3p161789jsn4dfc1862121c" },
            { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
        },
            };

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter154.p.rapidapi.com/user/details?username=bhmberkan"),
                Headers =
        {
            { "x-rapidapi-key", "f084fd302dmsh15466ef7d1b7ae3p161789jsn4dfc1862121c" },
            { "x-rapidapi-host", "twitter154.p.rapidapi.com" },
        },
            };





            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fberkan-turgut-2a277a232%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false&include_profile_status=false&include_company_public_url=false"),
                Headers =
    {
        { "x-rapidapi-key", "f084fd302dmsh15466ef7d1b7ae3p161789jsn4dfc1862121c" },
        { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            





            // Her iki isteği aynı anda asenkron olarak gönder
            var responseTasks = new[]
            {
        client.SendAsync(request),
        client2.SendAsync(request2),
        client3.SendAsync(request3)
    };

            await Task.WhenAll(responseTasks);

            var instagramResponse = responseTasks[0].Result;
            var twitterResponse = responseTasks[1].Result;
            var LinkedinResponse = responseTasks[2].Result;


            instagramResponse.EnsureSuccessStatusCode();
            twitterResponse.EnsureSuccessStatusCode();
            LinkedinResponse.EnsureSuccessStatusCode();

            var body = await instagramResponse.Content.ReadAsStringAsync();
            var body2 = await twitterResponse.Content.ReadAsStringAsync();
            var body3 = await LinkedinResponse.Content.ReadAsStringAsync();

            ResulInstagramFallowersDto resulInstagramFallowersDto = JsonConvert.DeserializeObject<ResulInstagramFallowersDto>(body);
            ResultTwitterFallowersDto resultTwitterFallowersDto = JsonConvert.DeserializeObject<ResultTwitterFallowersDto>(body2);
            ResultLinkedinDataDto resultLinkedinDataDto = JsonConvert.DeserializeObject<ResultLinkedinDataDto>(body3);

            ViewBag.username = resulInstagramFallowersDto.username;
            ViewBag.followers = resulInstagramFallowersDto.followers;
            ViewBag.following = resulInstagramFallowersDto.following;

            ViewBag.twUsarname = resultTwitterFallowersDto.username;
            ViewBag.twfallowers = resultTwitterFallowersDto.follower_count;
            ViewBag.twfallowing = resultTwitterFallowersDto.following_count;

            ViewBag.city = resultLinkedinDataDto.data.city;
            ViewBag.country = resultLinkedinDataDto.data.country;

            return View(new { InstagramData = resulInstagramFallowersDto, TwitterData = resultTwitterFallowersDto, LinkedinData= resultLinkedinDataDto });

           


        }
    }
}
