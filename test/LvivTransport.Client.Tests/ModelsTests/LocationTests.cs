using System;
using LvivTransport.Client.Core.Models;
using Xunit;

namespace LvivTransport.Client.Tests.ModelsTests
{
    public class LocationTests
    {
        [Fact]
        public void Location_LatitudeGreater90_ExceptionThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateLocation(90.0003, 0));
        }

        [Fact]
        public void Location_LatitudeLessMinus90_ExceptionThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateLocation(-92.3, 0));
        }

        [Fact]
        public void Location_LongitudeGreater180_ExceptionThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateLocation(0, 180.2));
        }

        [Fact]
        public void Location_LongitudeLessMinus180_ExceptionThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateLocation(0, -181.7));
        }

        private static Location CreateLocation(double latitude, double longitude)
        {
            return new Location(latitude, longitude);
        }
    }
}
