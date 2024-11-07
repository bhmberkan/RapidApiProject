using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.GuestDto
{
    public class ResultGuestDto
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
    }
}
