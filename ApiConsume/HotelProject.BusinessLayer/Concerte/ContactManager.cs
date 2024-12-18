﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concerte
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact TGetByID(int id)
        {
            return _contactDal.GetByID(id);
        }

        public int TGetContactCount()
        {
            return _contactDal.GetContactCount(); // entity geçiyoruz
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public void Tİmportantmessage(int id)
        {
            _contactDal.İmportantmessage(id);
        }

        public void TInsert(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void TUpdate(Contact t)
        {
            _contactDal.Update(t);
        }

        public int TİmportantMessageCount()
        {
            return _contactDal.İmportantMessageCount();
        }

        public void TUnimportant(int id)
        {
             _contactDal.Unimportant(id);
        }

        public int TBinMessageCount()
        {
            return _contactDal.BinMessageCount();
        }

        public void TBinMessageContact(int id)
        {
            _contactDal.BinMessageContact(id);
        }

        public void TUnBinMessage(int id)
        {
            _contactDal.UnBinMessage(id);
        }

        public List<Contact> TFirst3Message()
        {
            return _contactDal.First3Message();
        }
    }
}
