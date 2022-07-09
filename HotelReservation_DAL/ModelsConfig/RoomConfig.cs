using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservation_DAL.ModelsConfig
{
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            //--------------------Configration-------------------------
            builder.ToTable("rooms");

            builder.HasKey(r => r.id);
            builder.Property(r => r.id).UseIdentityColumn();

            builder.Property(r => r.finger_no).IsRequired();
            builder.Property(r => r.finger_no).IsRequired();

            builder.Property(r => r.is_vip).HasDefaultValue(0);

            //--------------------Data Seed-------------------------
            builder.HasData(
                   new Room
                   {
                       id = 1,
                       floor_no = 1,
                       finger_no = 1,
                       is_vip = false
                   },
                   new Room
                   {
                       id = 2,
                       floor_no = 1,
                       finger_no = 2,
                       is_vip = false,
                   },
                   new Room
                   {
                       id = 3,
                       floor_no = 2,
                       finger_no = 3,
                       is_vip = false
                   },
                   new Room
                   {
                       id = 4,
                       floor_no = 2,
                       finger_no = 5,
                       is_vip = true
                   }
               );
        }
    }
}
