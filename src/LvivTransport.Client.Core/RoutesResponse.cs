using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core
{
    [DataContract, Serializable]
    public class RoutesResponse : IServiceResponse
    {
        public ICollection<Route> Routes { get; set; } = new List<Route>();
    }
}
