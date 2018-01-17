using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LvivTransport.Client.Core.Models
{
    [DataContract]
    public class Route
    {
        [DataMember(Name = "external_id")]
        public int Id { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "stops")]
        public IEnumerable<int> Stops { get; set; }
    }
}
