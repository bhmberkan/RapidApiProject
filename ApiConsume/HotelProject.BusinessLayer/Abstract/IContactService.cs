using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {

        public int TGetContactCount();

        void Tİmportantmessage(int id);
        public int TİmportantMessageCount();

        void TUnimportant(int id);

        public int TBinMessageCount();

        void TBinMessageContact(int id);

        void TUnBinMessage(int id);

        List<Contact> TFirst3Message();

    }
}
