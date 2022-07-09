using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation_DAL.DataContxt;
using HotelReservation_DAL.Models;
using HotelReservation_DAL.Interfaces;

namespace HotelReservation_DAL.Repos
{
    public class RoomRepositort : Repository<Room>,IRoomRepositort
    {
        public RoomRepositort(HotelResrvation_context db_context) : base(db_context)
        {

        }
    }
}
