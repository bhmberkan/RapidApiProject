﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName); // aynı isimde birden fazla dosya yüklenmeye çalışırsa çakışmayı önlesin diye
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Images/" + fileName);
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return Created("",file);
        }
    }
}
