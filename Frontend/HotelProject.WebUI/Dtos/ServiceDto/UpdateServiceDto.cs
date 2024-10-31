using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Servis İkon linki giriniz.")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet Başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Hitmet Açıklaması Giriniz.")]
        [StringLength(500,ErrorMessage ="Hizmet açıklaması en fazla 500 karakter olabilir.")]
        public string Description { get; set; }
    }
}
