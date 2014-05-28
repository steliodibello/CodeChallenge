using System;
using System.ComponentModel.DataAnnotations;

namespace Bookings.Models.Entities
{
    public class Reservations
    {
        [Key]
        public Int32 SeatNumber { get; set; }

        [ConcurrencyCheck, Required(ErrorMessage = "pls provide Status")]
        public Int16 Status { get; set; }

        [ConcurrencyCheck]
        public DateTime? Date { get; set; }


        [ConcurrencyCheck]
        public String AgentName { get; set; }


        public String ClientName { get; set; }
    }
}