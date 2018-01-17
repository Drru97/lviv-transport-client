using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using LvivTransport.Client.Core.Abstract;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core.Response
{
    [DataContract, Serializable]
    public class RoutesResponse : ServiceResponse
    {
        public ICollection<Route> Routes { get; set; } = new List<Route>();
    }
}
