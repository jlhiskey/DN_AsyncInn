using System.Linq;
using DN_AsyncInn.Data;
using DN_AsyncInn.Models;
using DN_AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace AsyncInnTestSuite
{
    public class GetSetTestSuite
    {
        
        public class AmenitiesTestSuite
        {
            Amenities testAmenity = new Amenities() { ID = 1, Name = "name", };

            [Fact]
            public void TestingID()
            {
                Assert.Equal(1, testAmenity.ID);
            }

            [Fact]
            public void TestingName()
            {
                Assert.Equal("name", testAmenity.Name);
            }
        }

        public class HotelTestSuite
        {
            Hotel testHotel = new Hotel() { ID = 1, Name = "name", Address = "address", Phone = "123-123-1234"};

            [Fact]
            public void TestingID()
            {
                Assert.Equal(1, testHotel.ID);
            }

            [Fact]
            public void TestingName()
            {
                Assert.Equal("name", testHotel.Name);
            }

            [Fact]
            public void TestingAddress()
            {
                Assert.Equal("address", testHotel.Address);
            }

            [Fact]
            public void TestingPhone()
            {
                Assert.Equal("123-123-1234", testHotel.Phone);
            }
        }

        public class HotelRoomTestSuite
        {
            HotelRoom testHotelRoom = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true  };

            [Fact]
            public void TestingHotelID()
            {
                Assert.Equal(1, testHotelRoom.HotelID);
            }

            [Fact]
            public void TestingRoomNumber()
            {
                Assert.Equal(1, testHotelRoom.RoomNumber);
            }

            [Fact]
            public void TestingRoomID()
            {
                Assert.Equal(1, testHotelRoom.RoomID);
            }

            [Fact]
            public void TestingRate()
            {
                Assert.Equal(100, testHotelRoom.Rate);
            }

            [Fact]
            public void TestingPetFriendly()
            {
                Assert.True(testHotelRoom.PetFriendly);
            }
        }

        public class RoomTestSuite
        {   
            Room testRoom = new Room() { ID = 1, Name = "name", Layout = Layout.OneBedroom};

            [Fact]
            public void TestingID()
            {
                Assert.Equal(1, testRoom.ID);
            }

            [Fact]
            public void TestingName()
            {
                Assert.Equal("name", testRoom.Name);
            }

            [Fact]
            public void TestingLayout()
            {
                Assert.Equal(Layout.OneBedroom, testRoom.Layout);
            }
        }

        public class RoomAmenitiesTestSuite
        {
            RoomAmenities testRoomAmenity = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };

            [Fact]
            public void TestingID()
            {
                Assert.Equal(1, testRoomAmenity.AmenitiesID);
            }

            [Fact]
            public void TestingName()
            {
                Assert.Equal(1, testRoomAmenity.RoomID);
            }
        }
    }

    public class CRUDTestSuite
    {
        public class AmenitiesServicesTestSuite
        {
            [Fact]
            public async void CanCreateAmenity()
            {
                DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

                using (AsyncInnDbContext context = new AsyncInnDbContext(options))
                {
                    Amenities testAmenity = new Amenities() { ID = 1, Name = "name", };

                    AmenitiesManagementService amenityServices = new AmenitiesManagementService(context);

                    await amenityServices.CreateAmenity(testAmenity);

                    var result = context.Amenities.FirstOrDefault(a => a.ID == testAmenity.ID);

                    Assert.Equal(testAmenity, result);
                }
            }
        }
            

    }
}
