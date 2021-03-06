using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bandtracker
{
    public class VenuesTest : IDisposable
    {
        public VenuesTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void Test_VenuesEmptyAtFirst()
        {
            //Arrange, Act
            int result = Venue.GetAll().Count;

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_Save()
        {
            //Arrange
            Venue testVenue = new Venue("Vans Stadium");
            testVenue.Save();

            //Act
            List<Venue> result = Venue.GetAll();
            List<Venue> testList = new List<Venue>{testVenue};

            //Assert
            Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_Add_AddBandsToVenues()
        {
            //Arrange
            Venue testVenue = new Venue("Vans Stadium");
            testVenue.Save();
            Band testBand = new Band("Linkin Park");
            testBand.Save();

            //Act
            testVenue.AddBand(testBand.GetId());
            List<Band> allBands = testVenue.GetBands();
            List<Band> result = new List<Band>{testBand};

            //Assert
            Assert.Equal(result, allBands);
        }

        [Fact]
        public void Test_UpdateVenue_UpdatesVenueName()
        {
            //Arrange
            Venue testVenue = new Venue("Vans Stadium");
            testVenue.Save();

            //Act
            testVenue.UpdateVenue("Levi Stadium");
            Venue updatedVenue = Venue.FindVenue(testVenue.GetId());
            string result = updatedVenue.GetName();
            string expected = "Levi Stadium";

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test_DeleteBand_DeletesBandFromDatabase()
        {
            //Arrange
            Venue testVenue = new Venue("Vans Stadium");
            testVenue.Save();
            Band testBand = new Band("Linkin Park");
            testBand.Save();

            //Act
            testVenue.AddBand(testBand.GetId());
            testVenue.DeleteVenue();
            int result = Venue.GetAll().Count;

            //Assert
            Assert.Equal(result, 0);
        }

        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
        }
    }
}
