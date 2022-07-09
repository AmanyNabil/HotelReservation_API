using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HotelReservation_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation_DAL.ModelsConfig

{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {

        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            //-------------------- Configration -------------------------
            builder.ToTable("reservations");
            
            builder.HasKey(r => r.id);
            builder.Property(r => r.id).UseIdentityColumn();


            builder.Property(r => r.reservationDate).IsRequired().HasColumnType("Date") ;
           
            builder.Ignore(r => r.status);

            builder.HasOne<User>(u => u.user)
                        .WithMany(r => r.Reservations)
                        .HasForeignKey(r => r.user_id);

            builder.HasOne<Room>(u => u.room)
                        .WithMany(r => r.Reservations)
                        .HasForeignKey(r => r.room_id);

            //--------------------Data Seed-------------------------
            //builder.HasData(
            //new Reservation
            //{
            //    id = 1,
            //    reservationDate = new DateTime(2022, 6, 1),
            //    user_id = 1,
            //    room_id = 1
            //},
            //new Reservation
            //{
            //    id = 2,
            //    reservationDate = new DateTime(2022, 7, 4),
            //    user_id = 2,
            //    room_id = 3
            //}
            //);
        }
    }
}
