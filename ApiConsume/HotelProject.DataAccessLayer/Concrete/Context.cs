using HotelProject.EntityLayer;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-AV1UIG0;initial catalog=ApiDb; integrated security=true");
        }
        public DbSet<Room> Rooms { get; set; } 
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Subscribe> subscribes { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<Contact> contacts { get; set; }
    }
}
