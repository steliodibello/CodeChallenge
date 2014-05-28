using System.Data.Entity;
using System.Linq;
using Bookings.Models.Entities;

namespace Bookings.DAL
{
    public class BookingContext : DbContext, IBookingContext
    {
        public BookingContext()
            : base("Booking")
        {
             
        }
         
         public DbSet<Reservations> ReservationsDbSet { get; set; }
     
         

        public void Add<T>(T entity) where T: class 
        {
            this.Set<T>().Add(entity);
        }

        public void Save<T>()
        {
            this.SaveChanges();
        }
    }
}