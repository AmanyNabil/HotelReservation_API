using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelReservation_DAL.Models
{
    public class User
    {
       
        public int id { get; set; }
        public string name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
