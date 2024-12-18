﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad alanı gereklidir.")]
        public string Name { get; set; }  
        
        [Required(ErrorMessage ="Soyad alanı gereklidir.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı alanı gereklidir.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail alanı gereklidir.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor.")]
        public string ConfimPassword { get; set; }

       // public int WorkLocationID { get; set; } // bu eksik olursa kullanıcı ekleyemeyiz çünkü ilişkili tabloda bu eklediğimiz kayda göre ıd ataması lazım
       // ıd ye 1 dedik direkt appuserdeki o yüzden buraya bu tanımı geçmedim
    }
}
