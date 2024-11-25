using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IContactDal : IGenericDal<Contact>
    {
        public int GetContactCount(); // geriye değer döndürmesi için int formatıdna tanımladık voidden 

        void İmportantmessage(int id);

        public int İmportantMessageCount();

        void Unimportant(int id);

        public int BinMessageCount();

        void BinMessageContact(int id);

        void UnBinMessage(int id);

    }
}
