using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adını giriniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifreyi giriniz.")]
        public string Password { get; set; }

    }
}
