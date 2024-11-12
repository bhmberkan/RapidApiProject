using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public int MessageCategoryID { get; set; } // bire çok ilişki bu şekilde kuruluyor
        public MessageCategory? MessageCategory { get; set; }

        // burada ilişki eklediğimizde add-migration mig_add_MessaggeCategory dediğimizde tabloda veri olduğu için hata verecek
        // bu hatanın onune geçmek için veri tabanında ilgili tabloyu yani burada contacts tablosunu truncate ediyoruz içi boş olmalı yani
    }
}
