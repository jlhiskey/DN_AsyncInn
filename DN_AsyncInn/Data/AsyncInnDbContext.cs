using DN_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DN_AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key Associations
            modelBuilder.Entity<HotelRoom>().HasKey(hr => new { hr.HotelID, hr.RoomID });
            modelBuilder.Entity<RoomAmenities>().HasKey(ra => new { ra.AmenitiesID, ra.RoomID });

            modelBuilder.Entity<Hotel>().HasData(
               new Hotel
               {
                   ID = 1,
                   Name = "Seattle",
                   Address = "12345 1st Street Seattle, WA 98101",
                   Phone = "206-206-2006"
               },
               new Hotel
               {
                   ID = 2,
                   Name = "Redmond",
                   Address = "4567 2nd St Redmond, WA 98052",
                   Phone = "425-425-4225"
               },
                new Hotel
                {
                    ID = 3,
                    Name = "Los Angeles",
                    Address = "7894 8th Ave Los Angeles, CA 90001",
                    Phone = "323-323-3223"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "New York",
                    Address = "5678 109th St New York City, NY 10001",
                    Phone = "646-646-6446"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Miami",
                    Address = "6447 89th Ave Miami, FL 33101",
                    Phone = "786-786-7886"
                }
           );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Standard Studio",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 2,
                    Name = "Standard One Bedroom",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 3,
                    Name = "Standard Two Bedroom",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 4,
                    Name = "Restful Rainier",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Seahawks Snooze",
                    Layout = Layout.Studio
                }
            );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Air Conditioning"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Coffee Maker"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Mini Bar",
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Jacuzzi"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Ocean View"
                }
            );
        }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }


    }
}
