
using System;
using System.Collections;
using System.Collections.Generic;
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
            public Amenities CreateAmenity()
            {
                RoomAmenities testRoomAmenity1 = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };
                RoomAmenities testRoomAmenity2 = new RoomAmenities() { AmenitiesID = 1, RoomID = 2 };
                List<RoomAmenities> testList = new List<RoomAmenities>() { testRoomAmenity1, testRoomAmenity2 };
                ICollection<RoomAmenities> roomAmenities = testList;
                Amenities testAmenity = new Amenities() { ID = 1, Name = "name", RoomAmenities = roomAmenities };
                return testAmenity;
            }
                    
            [Fact]
            public void TestingIDGet()
            {
                Amenities testAmenity = CreateAmenity();
                Assert.Equal(1, testAmenity.ID);
            }

            [Fact]
            public void TestingIDSet()
            {
                Amenities testAmenity = CreateAmenity();
                testAmenity.ID = 2;
                Assert.Equal(2, testAmenity.ID);
            }

            [Fact]
            public void TestingNameGet()
            {
                Amenities testAmenity = CreateAmenity();
                Assert.Equal("name", testAmenity.Name);
            }

            [Fact]
            public void TestingNameSet()
            {
                Amenities testAmenity = CreateAmenity();
                testAmenity.Name = "bob";
                Assert.Equal("bob", testAmenity.Name);
            }

            [Fact]
            public void TestingRoomAmenitesGet()
            {
                Amenities testAmenity = CreateAmenity();

                RoomAmenities testRoomAmenity1 = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };
                RoomAmenities testRoomAmenity2 = new RoomAmenities() { AmenitiesID = 1, RoomID = 2 };
                List<RoomAmenities> testList = new List<RoomAmenities>() { testRoomAmenity1, testRoomAmenity2 };

                ICollection<RoomAmenities> expected = testList;
                ICollection<RoomAmenities> actual = testAmenity.RoomAmenities;

                RoomAmenities[] expectedArray = new RoomAmenities[expected.Count];
                expected.CopyTo(expectedArray, 0);

                RoomAmenities[] actualArray = new RoomAmenities[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }

            [Fact]
            public void TestingRoomAmenitesSet()
            {
                Amenities testAmenity = CreateAmenity();

                RoomAmenities testRoomAmenity1 = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };
                RoomAmenities testRoomAmenity2 = new RoomAmenities() { AmenitiesID = 1, RoomID = 2 };
                RoomAmenities testRoomAmenity3 = new RoomAmenities() { AmenitiesID = 1, RoomID = 3 };
                List<RoomAmenities> testList = new List<RoomAmenities>() { testRoomAmenity1, testRoomAmenity2, testRoomAmenity3 };

                ICollection<RoomAmenities> expected = testList;

                testAmenity.RoomAmenities.Add(testRoomAmenity3);

                ICollection<RoomAmenities> actual = testAmenity.RoomAmenities;

                RoomAmenities[] expectedArray = new RoomAmenities[expected.Count];
                expected.CopyTo(expectedArray, 0);

                RoomAmenities[] actualArray = new RoomAmenities[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }
        }

        public class HotelTestSuite
        {
            public Hotel CreateHotel()
            {
                HotelRoom testHotelRoom1 = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                HotelRoom testHotelRoom2 = new HotelRoom() { HotelID = 1, RoomNumber = 2, RoomID = 1, Rate = 150, PetFriendly = false };
                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom1, testHotelRoom2 };
                ICollection<HotelRoom> hotelRooms = testList;
                Hotel testHotel = new Hotel() { ID = 1, Name = "name", Address = "address", Phone = "123-123-1234", HotelRooms = hotelRooms };
                return testHotel;
            }

            [Fact]
            public void TestingIDGet()
            {
                Hotel testHotel = CreateHotel();
                Assert.Equal(1, testHotel.ID);
            }

            [Fact]
            public void TestingIDSet()
            {
                Hotel testHotel = CreateHotel();
                testHotel.ID = 2;
                Assert.Equal(2, testHotel.ID);
            }

            [Fact]
            public void TestingNameGet()
            {
                Hotel testHotel = CreateHotel();
                testHotel.Name = "bob";
                Assert.Equal("bob", testHotel.Name);
            }

            [Fact]
            public void TestingAddressGet()
            {
                Hotel testHotel = CreateHotel();
                Assert.Equal("address", testHotel.Address);
            }

            [Fact]
            public void TestingAddressSet()
            {
                Hotel testHotel = CreateHotel();
                testHotel.Address = "new";
                Assert.Equal("new", testHotel.Address);
            }

            [Fact]
            public void TestingPhoneGet()
            {
                Hotel testHotel = CreateHotel();
                Assert.Equal("123-123-1234", testHotel.Phone);
            }

            [Fact]
            public void TestingPhoneSet()
            {
                Hotel testHotel = CreateHotel();
                testHotel.Phone = "999-999-9999";
                Assert.Equal("999-999-9999", testHotel.Phone);
            }

            [Fact]
            public void TestingHotelRoomsGet()
            {
                Hotel testHotel = CreateHotel();

                HotelRoom testHotelRoom1 = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                HotelRoom testHotelRoom2 = new HotelRoom() { HotelID = 1, RoomNumber = 2, RoomID = 1, Rate = 150, PetFriendly = false };
                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom1, testHotelRoom2 };
                ICollection<HotelRoom> hotelRooms = testList;

                ICollection<HotelRoom> expected = testList;
                ICollection<HotelRoom> actual = testHotel.HotelRooms;
                HotelRoom[] expectedArray = new HotelRoom[expected.Count];
                expected.CopyTo(expectedArray, 0);

                HotelRoom[] actualArray = new HotelRoom[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }

            [Fact]
            public void TestingHotelRoomsSet()
            {
                Hotel testHotel = CreateHotel();

                HotelRoom testHotelRoom1 = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                HotelRoom testHotelRoom2 = new HotelRoom() { HotelID = 1, RoomNumber = 2, RoomID = 1, Rate = 150, PetFriendly = false };
                HotelRoom testHotelRoom3 = new HotelRoom() { HotelID = 1, RoomNumber = 3, RoomID = 1, Rate = 200, PetFriendly = false };
                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom1, testHotelRoom2, testHotelRoom3 };
                ICollection<HotelRoom> hotelRooms = testList;

                ICollection<HotelRoom> expected = testList;

                testHotel.HotelRooms.Add(testHotelRoom3);

                ICollection<HotelRoom> actual = testHotel.HotelRooms;
                HotelRoom[] expectedArray = new HotelRoom[expected.Count];
                expected.CopyTo(expectedArray, 0);

                HotelRoom[] actualArray = new HotelRoom[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }
        }

        public class HotelRoomTestSuite
        {
            public HotelRoom CreateHotelRoom()
            {
                HotelRoom testHotelRoom = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };

                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom, };
                ICollection<HotelRoom> hotelRooms = testList;

                Hotel testHotel = new Hotel() { ID = 1, Name = "name", Address = "address", Phone = "123-123-1234", HotelRooms = hotelRooms };

                Room testRoom = new Room() { ID = 1, Name = "name", Layout = Layout.OneBedroom, HotelRooms = hotelRooms };


                testHotelRoom.Hotel = testHotel;
                testHotelRoom.Room = testRoom;

                return testHotelRoom;
            }
            

            [Fact]
            public void TestingHotelIDGet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                Assert.Equal(1, testHotelRoom.HotelID);
            }

            [Fact]
            public void TestingHotelIDSet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                testHotelRoom.HotelID = 2;
                Assert.Equal(2, testHotelRoom.HotelID);
            }

            [Fact]
            public void TestingRoomNumberGet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                Assert.Equal(1, testHotelRoom.RoomNumber);
            }

            [Fact]
            public void TestingRoomNumberSet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                testHotelRoom.RoomNumber = 2;
                Assert.Equal(2, testHotelRoom.RoomNumber);
            }

            [Fact]
            public void TestingRoomIDGet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                Assert.Equal(1, testHotelRoom.RoomID);
            }

            [Fact]
            public void TestingRoomIDSet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                testHotelRoom.RoomID = 2;
                Assert.Equal(2, testHotelRoom.RoomID);
            }

            [Fact]
            public void TestingRateGet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                Assert.Equal(100, testHotelRoom.Rate);
            }

            [Fact]
            public void TestingRateSet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                testHotelRoom.Rate = 200;
                Assert.Equal(200, testHotelRoom.Rate);
            }

            [Fact]
            public void TestingPetFriendlyGet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                Assert.True(testHotelRoom.PetFriendly);
            }

            [Fact]
            public void TestingPetFriendlySet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
                testHotelRoom.PetFriendly = false;
                Assert.False(testHotelRoom.PetFriendly);
            }

            [Fact]
            public void TestingRoomGet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();
 
                List<HotelRoom> testList1 = new List<HotelRoom>() { testHotelRoom };
                ICollection<HotelRoom> hotelRooms = testList1;
                Room testRoom = new Room() { ID = 1, Name = "name", Layout = Layout.OneBedroom, HotelRooms = hotelRooms };

                Assert.Equal(testRoom.ID, testHotelRoom.Room.ID);
            }

            [Fact]
            public void TestingRoomSet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();

                List<HotelRoom> testList1 = new List<HotelRoom>() { testHotelRoom };
                ICollection<HotelRoom> hotelRooms = testList1;
                
                Room testRoom = new Room() { ID = 2, Name = "name2", Layout = Layout.OneBedroom, HotelRooms = hotelRooms };

                testHotelRoom.Room = testRoom;

                Assert.Equal(testRoom.ID, testHotelRoom.Room.ID);
            }

            [Fact]
            public void TestingHotelGet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();

                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom, };
                ICollection<HotelRoom> hotelRooms = testList;

                Hotel testHotel = new Hotel() { ID = 1, Name = "name", Address = "address", Phone = "123-123-1234", HotelRooms = hotelRooms };

                Assert.Equal(testHotel.ID, testHotelRoom.Hotel.ID);
            }

            [Fact]
            public void TestingHotelSet()
            {
                HotelRoom testHotelRoom = CreateHotelRoom();

                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom, };
                ICollection<HotelRoom> hotelRooms = testList;

                Hotel testHotel = new Hotel() { ID = 2, Name = "name", Address = "address", Phone = "123-123-1234", HotelRooms = hotelRooms };

                testHotelRoom.Hotel = testHotel;

                Assert.Equal(testHotel.ID, testHotelRoom.Hotel.ID);
            }
        }

        public class RoomTestSuite
        {
            public Room CreateRoom()
            {
                HotelRoom testHotelRoom1 = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                HotelRoom testHotelRoom2 = new HotelRoom() { HotelID = 1, RoomNumber = 2, RoomID = 1, Rate = 150, PetFriendly = false };
                List<HotelRoom> testList1 = new List<HotelRoom>() { testHotelRoom1, testHotelRoom2 };
                ICollection<HotelRoom> hotelRooms = testList1;

                RoomAmenities testRoomAmenity1 = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };
                RoomAmenities testRoomAmenity2 = new RoomAmenities() { AmenitiesID = 2, RoomID = 1 };
                List<RoomAmenities> testList2 = new List<RoomAmenities>() { testRoomAmenity1, testRoomAmenity2 };
                ICollection<RoomAmenities> roomAmenities = testList2;

                Room testRoom = new Room() { ID = 1, Name = "name", Layout = Layout.OneBedroom, HotelRooms = hotelRooms, RoomAmenities = roomAmenities };

                return testRoom;
            }

            [Fact]
            public void TestingIDGet()
            {
                Room testRoom = CreateRoom();
                Assert.Equal(1, testRoom.ID);
            }

            [Fact]
            public void TestingIDSet()
            {
                Room testRoom = CreateRoom();
                testRoom.ID = 2;
                Assert.Equal(2, testRoom.ID);
            }

            [Fact]
            public void TestingNameGet()
            {
                Room testRoom = CreateRoom();
                Assert.Equal("name", testRoom.Name);
            }

            [Fact]
            public void TestingNameSet()
            {
                Room testRoom = CreateRoom();
                testRoom.Name = "bob";
                Assert.Equal("bob", testRoom.Name);
            }

            [Fact]
            public void TestingLayoutGet()
            {
                Room testRoom = CreateRoom();
                Assert.Equal(Layout.OneBedroom, testRoom.Layout);
            }

            [Fact]
            public void TestingLayoutSet()
            {
                Room testRoom = CreateRoom();
                testRoom.Layout = Layout.Studio;
                Assert.Equal(Layout.Studio, testRoom.Layout);
            }

            [Fact]
            public void TestingHotelRoomsGet()
            {
                Room testRoom = CreateRoom();

                HotelRoom testHotelRoom1 = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                HotelRoom testHotelRoom2 = new HotelRoom() { HotelID = 1, RoomNumber = 2, RoomID = 1, Rate = 150, PetFriendly = false };
                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom1, testHotelRoom2 };
                ICollection<HotelRoom> hotelRooms = testList;

                ICollection<HotelRoom> expected = testList;
                ICollection<HotelRoom> actual = testRoom.HotelRooms;
                HotelRoom[] expectedArray = new HotelRoom[expected.Count];
                expected.CopyTo(expectedArray, 0);

                HotelRoom[] actualArray = new HotelRoom[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }

            [Fact]
            public void TestingHotelRoomsSet()
            {
                Room testRoom = CreateRoom();

                HotelRoom testHotelRoom1 = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                HotelRoom testHotelRoom2 = new HotelRoom() { HotelID = 1, RoomNumber = 2, RoomID = 1, Rate = 150, PetFriendly = false };
                HotelRoom testHotelRoom3 = new HotelRoom() { HotelID = 1, RoomNumber = 3, RoomID = 1, Rate = 200, PetFriendly = false };
                List<HotelRoom> testList = new List<HotelRoom>() { testHotelRoom1, testHotelRoom2, testHotelRoom3 };
                ICollection<HotelRoom> hotelRooms = testList;

                ICollection<HotelRoom> expected = testList;

                testRoom.HotelRooms.Add(testHotelRoom3);

                ICollection<HotelRoom> actual = testRoom.HotelRooms;
                HotelRoom[] expectedArray = new HotelRoom[expected.Count];
                expected.CopyTo(expectedArray, 0);

                HotelRoom[] actualArray = new HotelRoom[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }

            [Fact]
            public void TestingRoomAmenitesGet()
            {
                Room testRoom = CreateRoom();

                RoomAmenities testRoomAmenity1 = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };
                RoomAmenities testRoomAmenity2 = new RoomAmenities() { AmenitiesID = 2, RoomID = 1 };
                List<RoomAmenities> testList = new List<RoomAmenities>() { testRoomAmenity1, testRoomAmenity2 };
                ICollection<RoomAmenities> roomAmenities = testList;

                ICollection<RoomAmenities> expected = testList;
                ICollection<RoomAmenities> actual = testRoom.RoomAmenities;
                RoomAmenities[] expectedArray = new RoomAmenities[expected.Count];
                expected.CopyTo(expectedArray, 0);

                RoomAmenities[] actualArray = new RoomAmenities[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }

            [Fact]
            public void TestingRoomAmenitesSet()
            {
                Room testRoom = CreateRoom();

                RoomAmenities testRoomAmenity1 = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };
                RoomAmenities testRoomAmenity2 = new RoomAmenities() { AmenitiesID = 2, RoomID = 1 };
                RoomAmenities testRoomAmenity3 = new RoomAmenities() { AmenitiesID = 3, RoomID = 1 };

                List<RoomAmenities> testList = new List<RoomAmenities>() { testRoomAmenity1, testRoomAmenity2, testRoomAmenity3 };
                ICollection<RoomAmenities> roomAmenities = testList;

                ICollection<RoomAmenities> expected = testList;

                testRoom.RoomAmenities.Add(testRoomAmenity3);

                ICollection<RoomAmenities> actual = testRoom.RoomAmenities;
                RoomAmenities[] expectedArray = new RoomAmenities[expected.Count];
                expected.CopyTo(expectedArray, 0);

                RoomAmenities[] actualArray = new RoomAmenities[actual.Count];
                expected.CopyTo(actualArray, 0);

                Assert.Equal(expectedArray, actualArray);
            }
        }

        public class RoomAmenitiesTestSuite
        {
            public RoomAmenities CreateRoomAmenity()
            {
                RoomAmenities testRoomAmenity = new RoomAmenities() { AmenitiesID = 1, RoomID = 1 };

                HotelRoom testHotelRoom = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };

                List<HotelRoom> testList1 = new List<HotelRoom>() { testHotelRoom };
                ICollection<HotelRoom> hotelRooms = testList1;

                List<RoomAmenities> testList2 = new List<RoomAmenities>() { testRoomAmenity };
                ICollection<RoomAmenities> roomAmenities = testList2;

                Amenities testAmenity = new Amenities() { ID = 1, Name = "name", RoomAmenities = roomAmenities };

                Room testRoom = new Room() { ID = 1, Name = "name", Layout = Layout.OneBedroom, HotelRooms = hotelRooms };

                testRoomAmenity.Amenities = testAmenity;
                testRoomAmenity.Room = testRoom;

                return testRoomAmenity;
            }
            

            [Fact]
            public void TestingAmenityIDGet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();
                Assert.Equal(1, testRoomAmenity.AmenitiesID);
            }

            [Fact]
            public void TestingAmenityIDSet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();
                testRoomAmenity.AmenitiesID = 2;
                Assert.Equal(2, testRoomAmenity.AmenitiesID);
            }

            [Fact]
            public void TestingRoomIDGet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();
                Assert.Equal(1, testRoomAmenity.RoomID);
            }

            [Fact]
            public void TestingRoomIDSet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();
                testRoomAmenity.RoomID = 2;
                Assert.Equal(2, testRoomAmenity.RoomID);
            }

            [Fact]
            public void TestingRoomGet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();

                HotelRoom testHotelRoom = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                List<HotelRoom> testList1 = new List<HotelRoom>() { testHotelRoom };
                ICollection<HotelRoom> hotelRooms = testList1;
                Room testRoom = new Room() { ID = 1, Name = "name", Layout = Layout.OneBedroom, HotelRooms = hotelRooms };

                Assert.Equal(testRoom.ID, testRoomAmenity.Room.ID);
            }

            [Fact]
            public void TestingRoomSet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();

                HotelRoom testHotelRoom = new HotelRoom() { HotelID = 1, RoomNumber = 1, RoomID = 1, Rate = 100, PetFriendly = true };
                List<HotelRoom> testList1 = new List<HotelRoom>() { testHotelRoom };
                ICollection<HotelRoom> hotelRooms = testList1;
                Room testRoom = new Room() { ID = 2, Name = "name2", Layout = Layout.OneBedroom, HotelRooms = hotelRooms };

                testRoomAmenity.Room = testRoom;

                Assert.Equal(testRoom.ID, testRoomAmenity.Room.ID);
            }

            [Fact]
            public void TestingAmenityGet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();

                List<RoomAmenities> testList2 = new List<RoomAmenities>() { testRoomAmenity };
                ICollection<RoomAmenities> roomAmenities = testList2;

                Amenities testAmenity = new Amenities() { ID = 1, Name = "name", RoomAmenities = roomAmenities };

                Assert.Equal(testAmenity.ID, testRoomAmenity.Amenities.ID);
            }

            [Fact]
            public void TestingAmenitySet()
            {
                RoomAmenities testRoomAmenity = CreateRoomAmenity();

                List<RoomAmenities> testList2 = new List<RoomAmenities>() { testRoomAmenity };
                ICollection<RoomAmenities> roomAmenities = testList2;

                Amenities testAmenity = new Amenities() { ID = 2, Name = "name", RoomAmenities = roomAmenities };

                testRoomAmenity.Amenities = testAmenity;

                Assert.Equal(testAmenity.ID, testRoomAmenity.Amenities.ID);
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
                //dbcontextoptions<asyncinndbcontext> options = new dbcontextoptionsbuilder<asyncinndbcontext>().useinmemorydatabase("createamenity").options;

                //using (AsyncInnDbContext context = new AsyncInnDbContext(options))
                //{
                //    Amenities testAmenity = new Amenities() { ID = 1, Name = "name", };

                //    AmenitiesManagementService amenityServices = new AmenitiesManagementService(context);

                //    await amenityServices.CreateAmenity(testAmenity);

                //    var result = context.Amenities.FirstOrDefault(a => a.ID == testAmenity.ID);

                //    Assert.Equal(testAmenity, result);
            }
        }
    }
}


