using System;
using LvivTransport.Client.Core.Abstract;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core.Request
{
    public class StopsNearbyRequest : ServiceRequest
    {
        private Location _location;
        private int _range;

        public StopsNearbyRequest(double latitude, double longitude, int range)
        {
            _location = new Location(latitude, longitude);
            _range = range;
            Uri = new Uri($"/api/closest?latitude={_location.Latitude}&longitude={_location.Longitude}&accuracy={_range}", UriKind.Relative);
        }

        public StopsNearbyRequest(Location location, int range) : this(location.Latitude, location.Longitude, range) { }
    }
}
