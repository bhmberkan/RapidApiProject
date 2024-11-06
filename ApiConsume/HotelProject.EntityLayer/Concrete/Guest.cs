using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Guest
    {
        public int GuestID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
    }
}
