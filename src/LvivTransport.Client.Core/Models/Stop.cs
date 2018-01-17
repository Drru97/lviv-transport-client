using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LvivTransport.Client.Core.Models
{
    [DataContract]
    public class Stop
    {
        [DataMember(Name = "code")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public double Longitude { get; set; }

        [DataMember(Name = "timetable")]
        public IEnumerable<Vehicle> Timetable { get; set; }

        [DataMember(Name = "routes")]
        public IEnumerable<string> Routes { get; set; }
    }
}
