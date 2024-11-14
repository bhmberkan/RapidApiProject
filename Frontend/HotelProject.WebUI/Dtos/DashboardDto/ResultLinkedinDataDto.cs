using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.DashboardDto
{
    public class ResultLinkedinDataDto
    {


        public Data data { get; set; }



        public class Data
        {

            public string city { get; set; }

            public string country { get; set; }
        }



    }
}
