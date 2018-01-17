using System;

namespace LvivTransport.Client.Core.Models
{
    public class Location
    {
        private double _latitude;
        private double _longitude;

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude
        {
            get => _latitude;
            set
            {
                if (Math.Abs(value) > 90)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Latitude must be in range [-90, 90]");
                }
                _latitude = value;
            }
        }

        public double Longitude
        {
            get => _longitude;
            set
            {
                if (Math.Abs(value) > 180)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Longitude must be in range [-180, 180]");
                }
                _longitude = value;
            }
        }
    }
}
