using HotelReservation_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation_DAL.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        IEnumerable<Reservation> GetUserReservations(int userId);
        IEnumerable<Reservation> GetRoomReservations(int roomId);
        bool UpdateRoomReservations(Reservation oldRes,int roomId);
        bool UpdateRoomReservations(Reservation oldRes, DateTime resDate);
        bool UpdateRoomReservations(Reservation oldRes, int room_id,DateTime resDate);
    }
}
