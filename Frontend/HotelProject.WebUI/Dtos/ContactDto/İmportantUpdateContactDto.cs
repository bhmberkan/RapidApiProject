using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class İmportantUpdateContactDto
    {
        public int ContactID { get; set; }
        public string situation { get; set; } = "Önemli";

        // sadece bu alanı önemli olarak değiştireceğimiz için ayrıca diğer alanları da girmedim.
    }
}
