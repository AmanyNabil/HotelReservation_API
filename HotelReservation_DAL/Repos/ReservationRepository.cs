using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation_DAL.DataContxt;
using HotelReservation_DAL.Interfaces;
using HotelReservation_DAL.Models;

namespace HotelReservation_DAL.Repos
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
       
        public ReservationRepository(HotelResrvation_context db_context) : base(db_context)
        {

        }
        public  IEnumerable<Reservation> GetRoomReservations(int roomId)
        {
            try
            {

                return  db_context.reservations.Where(r => r.room_id == roomId).ToList() ;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public  IEnumerable<Reservation> GetUserReservations(int userId)
        {
            try
            {
                return  db_context.reservations.Where(r => r.user_id == userId).ToList();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public  bool UpdateRoomReservations(Reservation oldRes, int room_id)
        {
            try
            {
                Reservation res = oldRes;
                res.room_id = room_id;
              
                db_context.Update(res);
                db_context.SaveChanges();
             
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
        public  bool UpdateRoomReservations(Reservation oldRes, DateTime resDate)
        {
            try
            {
                Reservation res = oldRes;
                res.reservationDate= resDate;

                db_context.Update(res);
                db_context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.Message);
            }
        }
        public  bool UpdateRoomReservations(Reservation oldRes,int room_id, DateTime resDate)
        {
            try
            {
                Reservation res = oldRes;
                res.room_id = room_id;
                res.reservationDate = resDate;
                db_context.Update(res);
                db_context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new NotImplementedException(ex.Message);
            }
        }

    }
}
