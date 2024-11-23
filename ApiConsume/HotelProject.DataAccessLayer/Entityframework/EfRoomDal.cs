using HotelProject.DataAccessLayer.Abstract;
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
  public  class EfRoomDal :GenericRepository<Room> , IRoomDal
    { 
        public EfRoomDal(Context context) : base(context)
        {

        }

        public List<Room> First3Room()
        {
            var context = new Context();
            var values = context.Rooms.OrderBy(x => x.RoomID).Take(3).ToList();
            return values;
        }

        public int RoomCount()
        {
            var context = new Context();
            var values = context.Rooms.Count();
            return values;
        }
    }
}
