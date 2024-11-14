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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {

        }

        public void BookingStatusChangeApproved(Booking booking)
        {

            var contex = new Context();
            var values = contex.bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
            values.Status = "Onaylandı";
            contex.SaveChanges();

        }

        public void BookingStatusChangeApproved2(int id)
        {
            var contex = new Context();
            var values = contex.bookings.Find(id);
            values.Status = "Onaylandı";
            contex.SaveChanges();
        }

        public int GetBookingCount()
        {
            var context = new Context();
            var value = context.bookings.Count();
            return value;
        }

        public List<Booking> Last6Bookings()
        {
            var contex = new Context();
            var values = contex.bookings.OrderByDescending(x => x.BookingID).Take(6).ToList(); // son6 kaydı donecek
            return values;
        }
    }
}
