using HotelReservation_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace HotelReservation_DAL.ModelsConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //--------------------Configration-------------------------
            builder.ToTable("users");

            builder.HasKey(u => u.id);
            builder.Property(u => u.id).UseIdentityColumn();

            builder.Property(u => u.name).IsRequired().HasMaxLength(100);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);


            //--------------------Data Seed-------------------------
            builder.HasData(
                    new User
                    {
                        id = 1,
                        name = "Amany Nabil",
                        Email = "Amani.nabil@hotmail.com"
                    },
                    new User
                    {
                        id = 2,
                        name = "Ahmed Mohamed",
                        Email = "Ahmed.M@hotmail.com"
                    },
                    new User
                    {
                        id = 3,
                        name = "Ali Said",
                        Email = "Ali.Said@hotmail.com"
                    },
                    new User
                    {
                        id = 4,
                        name = "Tamed Mohamed",
                        Email = "Tamer.M@hotmail.com"
                    }
                );

        }
    }
}
