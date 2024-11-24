﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Entityframework
{
   public class EfContactDal :GenericRepository<Contact>, IContactDal
    {
        public EfContactDal(Context context) : base(context)
        {

        }

        public int GetContactCount()
        { // entitye özgü metod kullanıyoruz
            var context = new Context();
            return context.contacts.Count();
             
        }

        public void İmportantmessage(int id)
        {
            var context = new Context();
            var values = context.contacts.Find(id);
            values.situation = "Önemli";
            context.SaveChanges();
        }

        public int İmportantMessageCount()
        {
            var context = new Context();
            return context.contacts.Where(x => x.situation == "Önemli").Count();
        }
    }
}
