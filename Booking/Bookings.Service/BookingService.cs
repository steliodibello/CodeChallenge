using System;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Bookings.DAL;
using Bookings.Models;

namespace Bookings.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Required)]
  public  class BookingService :IBookingService
  {
        private ReservationRepository _repository = null;
        private UserContext _user = null;

        public BookingService()
        {
            _repository = new ReservationRepository();
            _user = ClaimsManager.GetUserFromContext();
        }

     

        public List<int> GetAvaliableSeats(string availableSeats)
        {


            return _repository.GetAndPreBookAvailableSeats(Int32.Parse(availableSeats), _user.UserName);
        }

        public List<int> GetOtherAvaliableSeats(RequestOtherSeats req)
        {

            return _repository.GetAndPreBookAvailableSeats(req.SeatsRequested, req.PreviousSeates, _user.UserName);
 
        }

      public  void BookSeats(BookSeats req)
      {
          _repository.BookSeats(req.SeatesToBook, req.ClientName, _user.UserName);
 
      }
    }
}
