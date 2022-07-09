using HotelReservation_DAL.Interfaces;
using HotelReservation_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation_BAL
{
    public enum status { Past, Upcoming }
    public class ReservationService
    {
        private readonly IReservationRepository reservation;

        public ReservationService(IReservationRepository reservation)
        {
            this.reservation = reservation;
        }
        //------------------------------------------------------
        public bool CheckRoomAvailability(IEnumerable<Reservation> roomReservations, DateTime resDate)
        {
            bool isRoomAvailable = true;

            foreach (Reservation r in roomReservations)
            {
                if (resDate == r.reservationDate) 
                {
                    isRoomAvailable = false;
                    break;
                }
            }
            return isRoomAvailable;
        }

        public IEnumerable<Reservation> GetUserReservationsStatus(int user_id)
        {
          
            IEnumerable<Reservation> userReservations = (IEnumerable<Reservation>)GetUserReservations(user_id);

            foreach (Reservation r in userReservations)
            {
                if (DateTime.Now < r.reservationDate)
                {
                    r.status = status.Upcoming.ToString();
                   
                }
                else
                {
                    r.status = status.Past.ToString();
                }

            }
            return userReservations;
        }
        //------------------------------------------------------
        public Reservation GetReservation(int id)
        {
            return reservation.GetById(id);
        }
        public Task<IEnumerable<Reservation>> GetAllReservation()
        {
            return reservation.GetAll();
        }
        public IEnumerable<Reservation> GetRoomReservations(int room_id)
        {
            return reservation.GetRoomReservations(room_id);
        }
        public IEnumerable<Reservation> GetUserReservations(int user_id)
        {
            return reservation.GetUserReservations(user_id);
        }

        public async Task<Reservation> CreateReservation(Reservation res)
        {
            Reservation createdRes = null;

            if (CheckRoomAvailability((IEnumerable<Reservation>)GetRoomReservations(res.room_id), res.reservationDate))
            {
                createdRes = await reservation.Create(res);
            }

            return  createdRes;
        }

        public bool EditReservsation(Reservation oldReservation, int room_id)
        {
            try
            {
                if (CheckRoomAvailability((IEnumerable<Reservation>)GetRoomReservations(room_id), oldReservation.reservationDate))
                {
                   if( reservation.UpdateRoomReservations(oldReservation, room_id))
                    return true;
                   else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditReservsation(Reservation oldReservation, DateTime resDate)
        {
            try
            {
                if (CheckRoomAvailability((IEnumerable<Reservation>)GetRoomReservations(oldReservation.room_id),resDate))
                {
                    reservation.UpdateRoomReservations(oldReservation, resDate);
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EditReservsation(Reservation oldReservation, int room_id, DateTime resDate)
        {
            try
            {
                if (CheckRoomAvailability((IEnumerable<Reservation>)GetRoomReservations(room_id), resDate))
                {
                    reservation.UpdateRoomReservations(oldReservation, room_id, resDate);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteReservation(Reservation res)
        {
            try
            {
                reservation.Delete(res);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
