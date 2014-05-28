using Bookings.DAL;
using Bookings.Models.Entities;

namespace LBi.Microsoft.BigBet.Core.DataEntities
{
    /// <summary>
    /// Custom Initializer to fill up reservations table with
    /// </summary>
    public  class InitializeRepository 
    {
        private BookingContext repository;

        public void Initialize()
        {
            repository = new BookingContext();

            for(int i=1; i<=60; i++)
            {
                repository.Add(new Reservations
                                   {AgentName = "", ClientName = "", SeatNumber = i, Status = 0});

            }
            repository.SaveChanges();
       
        }
    }
}