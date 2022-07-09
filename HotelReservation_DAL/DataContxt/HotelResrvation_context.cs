using System;
using System.Collections.Generic;
using System.Text;
using HotelReservation_DAL.Models;
using Microsoft.EntityFrameworkCore;
using HotelReservation_DAL.ModelsConfig;
using System.Configuration;

namespace HotelReservation_DAL.DataContxt
{
    public class HotelResrvation_context : DbContext
    {
        public HotelResrvation_context(DbContextOptions<HotelResrvation_context> options)
           : base(options)
        {
            //  Database.Migrate();
        }

        public DbSet<User> users { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoomConfig());
            modelBuilder.ApplyConfiguration(new ReservationConfig());
        }

    }
}
