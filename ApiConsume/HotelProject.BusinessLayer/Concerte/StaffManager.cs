using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concerte
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _ıstaffDal;

      
        public StaffManager(IStaffDal ıstaffDal)
        {
            _ıstaffDal = ıstaffDal;
        }

        public void TDelete(Staff t)
        {
            _ıstaffDal.Delete(t);
        }

        public List<Staff> TFirst4staff()
        {
          return  _ıstaffDal.First4staff();
        }

        public Staff TGetByID(int id)
        {
            return _ıstaffDal.GetByID(id);
        }

        public List<Staff> TGetList()
        {
            return _ıstaffDal.GetList();
        }

        public int TGetStaffCount()
        {
            return _ıstaffDal.GetStaffCount();
        }

        public void TInsert(Staff t)
        {
            _ıstaffDal.Insert(t);
        }

        public List<Staff> TLast4Staff()
        {
            return _ıstaffDal.Last4Staff();
        }

        public void TUpdate(Staff t)
        {
            _ıstaffDal.Update(t);
        }
    }
}
