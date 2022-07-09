using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservation_DAL.Models
{
  
    public class Room
    {
        public int id { get; set; }

        public int floor_no { get; set; }

        public int finger_no { get; set; }

        public bool is_vip { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
