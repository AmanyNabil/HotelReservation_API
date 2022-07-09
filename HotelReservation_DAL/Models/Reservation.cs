using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservation_DAL.Models
{
    // [Table("reservations")]
    public class Reservation
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int room_id { get; set; }
        public DateTime reservationDate { get; set; }

        public string status { get; set; }

        public User user { get; set; }

        public Room room { get; set; }
    }
}
