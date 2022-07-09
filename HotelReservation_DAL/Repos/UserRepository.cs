using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation_DAL.Models;
using HotelReservation_DAL.Interfaces;
using HotelReservation_DAL.DataContxt;

namespace HotelReservation_DAL.Repos
{
    public class UserRepository : Repository<User>,IUserRepository
    {
        public UserRepository(HotelResrvation_context db_context) : base(db_context)
        {

        }
    }
}
