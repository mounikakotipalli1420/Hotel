using HotelBookingApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelBookingApp.Contexts
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        //public object User { get; internal set; }
        public DbSet<Booking> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Room>()
            // .HasOne(r => r.Hotel)
            //.WithMany(h => h.Rooms)
            // .HasForeignKey(r => r.HotelId);
            modelBuilder.Entity<Room>()
               .Property(r => r.Price)
               .HasColumnType("decimal(18, 2)");

            // Add other configurations as needed
        }
    }
}

