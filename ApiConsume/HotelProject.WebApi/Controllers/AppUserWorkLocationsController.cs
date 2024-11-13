using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationsController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserWorkLocationsController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            //   var values = _appUserService.TUserListWithLocations();
            Context context = new Context();
            var values = context.Users.Include(x => x.workLocation).Select(y => new AppUserWorkLocationModel
            {
                Name = y.Name,
                Surname = y.Surname,
                WorkLocationID = y.WorkLocationID.ToString(),
                WorkLocationName = y.workLocation.WorkLocationName,
                City=y.City,
                Country=y.Country,
                Gender=y.Gender,
                ImageUrl=y.ImageUrl
            }).ToList();  // nested bir yapı yani ilişkili tablolardaki alt kısım bu şekilde çekiliyor
            return Ok(values);
        }
    }
}
