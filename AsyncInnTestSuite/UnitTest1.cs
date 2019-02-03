using System.Linq;
using DN_AsyncInn.Data;
using DN_AsyncInn.Models;
using DN_AsyncInn.Models.Services;
using Xunit;

namespace AsyncInnTestSuite
{
    public class ModelTestSuite
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
    }
}
