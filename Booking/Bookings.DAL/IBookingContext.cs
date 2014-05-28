using System.Linq;
using Bookings.Models.Entities;

namespace Bookings.DAL
{
    public interface IBookingContext
    {
         void Add<T>(T entity) where T : class;
        void Save<T>();
    }
}