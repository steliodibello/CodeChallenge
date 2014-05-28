using System;
using System.Collections.Generic;
using System.Linq;
using Bookings.Models.Entities;
using Bookings.Models.Exceptions;

namespace Bookings.DAL
{
    public class ReservationRepository
    {
        private BookingContext repository;

        public ReservationRepository()
        {
            repository = new BookingContext();
        }

        public List<Int32> GetAndPreBookAvailableSeats(int seatsRequested, string agentName)
        {
            return GetAndPreBookAvailableSeats(seatsRequested, null, agentName);
        }



        public void CancelPreviousPreBook(List<int> seatsToExclude)
        {
            var previousPreBook = repository.ReservationsDbSet.Where(x => seatsToExclude.Contains(x.SeatNumber));
            foreach (var seat in previousPreBook)
            {
                seat.Status = (int)BookingStatus.NeverBooked;
                seat.AgentName = String.Empty;
                seat.Date = null;
            }

            repository.SaveChanges();


        }


        public List<Int32> GetAndPreBookAvailableSeats(int seatsRequested, List<int> seatsToExclude,string agentName )
        {
            var availableSeats = repository.ReservationsDbSet.Where(x => (x.Status == (int)BookingStatus.NeverBooked));

            if (seatsToExclude != null)
            {
                availableSeats = availableSeats.Where(x => !seatsToExclude.Contains(x.SeatNumber));
            }

            if (availableSeats.Count() >= seatsRequested)
            {
                var preassigedSeats = availableSeats.Take(seatsRequested);
                var seats = new List<Int32>();

                foreach (var seat in preassigedSeats)
                {
                    seat.Status = (int)BookingStatus.PreBooked;
                    seat.AgentName = agentName;
                    seat.Date = DateTime.Now;
                    seats.Add(seat.SeatNumber);
                }


                //Here we could have a concurrency exception if 2 agents / users are trying to get the same seats at the same time...
                //this event is very unlikely, and so we don't want to handle this exception on the service side, but just trowing the exception to the user
                //who can decide to request other seats, in case of heavy traffic we could consider to implement a retry in case of concurrency exception...
                //this is the only "critical" point of the application where we have to protect users from data collisions...                  
                repository.SaveChanges();

                if (seatsToExclude != null)
                {
                    CancelPreviousPreBook(seatsToExclude);
                }

              
              
                 return seats;


            }
            else
            {
                throw new NotEnoughSeatException();
            }
        }

        public void BookSeats(List<int> seatsToBook, string clientName, string agentName)
        {
            var availableSeats = repository.ReservationsDbSet.Where(x =>  seatsToBook.Contains(x.SeatNumber) );

          
                foreach (var seat in availableSeats )
                {
                    seat.Status = (int) BookingStatus.Booked;
                    seat.AgentName = agentName;
                    seat.Date = DateTime.Now;
                    seat.ClientName = clientName;
                }

                repository.SaveChanges();
             
        }


     }
}
