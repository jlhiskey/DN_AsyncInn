
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
    }
}
