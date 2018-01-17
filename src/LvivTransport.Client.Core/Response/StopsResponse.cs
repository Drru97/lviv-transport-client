using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LvivTransport.Client.Core.Abstract;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core.Response
{
    [DataContract, Serializable]
    public class StopsResponse : ServiceResponse
    {
        public ICollection<Stop> Stops { get; set; } = new List<Stop>();
    }
}
