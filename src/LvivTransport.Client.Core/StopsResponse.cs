using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core
{
    [DataContract, Serializable]
    public class StopsResponse : IServiceResponse
    {
        public ICollection<Stop> Stops { get; set; } = new List<Stop>();
    }
}
