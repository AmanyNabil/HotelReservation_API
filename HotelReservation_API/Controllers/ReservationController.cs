using HotelReservation_BAL;
using HotelReservation_DAL.DataContxt;
using HotelReservation_DAL.Interfaces;
using HotelReservation_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService resService;

      
         public ReservationController(ReservationService resService)
        {
            this.resService = resService;
        }

        [HttpPost("CreateReservation")]
        public Task<Reservation> CreateReservation([FromBody] Reservation res)
        {
            try
            {
                return resService.CreateReservation(res);

            }
            catch (Exception)
            {

                return null;
            }
        }


        [HttpDelete("DeleteReservation")]
        public bool DeleteReservation(Reservation res)
        {
            try
            {
                resService.DeleteReservation(res);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [HttpPut("UpdateReservationByRoom")]
        public bool UpdateReservation(Reservation res, int room_id)
        {
            try
            {
                return resService.EditReservsation(res, room_id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut("UpdateReservationByDate")]
        public bool UpdateReservation(Reservation res, DateTime resDate)
        {
            try
            {
                return resService.EditReservsation(res, resDate);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetUserReservationsStatus")]
        public IEnumerable<Reservation> GetUserResStatus(int user_id)
        {
            try
            {
                return resService.GetUserReservationsStatus(user_id);

            }
            catch (Exception)
            {

                return null;
            }
        }


        //-------------------------------------------------------------------------------------------------
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetReservation")]
        public Reservation GetReservationByID(int id)
        {
            try
            {
                return resService.GetReservation(id);

            }
            catch (Exception)
            {

                return null;
            }
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetReservations")]
        public async Task<IEnumerable<Reservation>> GetAllRes()
        {
            try
            {
                return await resService.GetAllReservation();

            }
            catch (Exception)
            {

                return null;
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetRoomReservations")]
        public IEnumerable<Reservation> GetRoomRes(int room_id)
        {
            try
            {
                return resService.GetRoomReservations(room_id);

            }
            catch (Exception)
            {

                return null;
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("GetUserReservations")]
        public IEnumerable<Reservation> GetUserRes(int user_id)
        {
            try
            {
                return resService.GetUserReservations(user_id);

            }
            catch (Exception)
            {

                return null;
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("CheckRoomAvailability")]
        public string CheckRoomAvailability( int room_id,DateTime resDate)
        {
            try
            {
                return resService.CheckRoomAvailability(resService.GetRoomReservations(room_id), resDate) ? "Room Is Available" : "Room Is not Available"; ;

            }
            catch (Exception)
            {

                return null;
            }
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete("DeleteReservationByID")]
        public bool DeleteReservation(int res_id)
        {
            try
            {
                return resService.DeleteReservation(resService.GetReservation(res_id));
                 
            }
            catch (Exception)
            {
                return false;
            }
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("UpdateReservationByRoom_Date")]
        public bool UpdateReservation(Reservation res,int room_id, DateTime resDate)
        {
            try
            {
                return resService.EditReservsation(res, room_id, resDate);
            }
            catch (Exception)
            {
                return false;
            }
        }

      
        
        

    }
}
