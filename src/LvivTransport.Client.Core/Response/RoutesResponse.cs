using System.Collections.Generic;
using LvivTransport.Client.Core.Abstract;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core.Response
{
    public class RoutesResponse : ServiceResponse
    {
        public ICollection<Route> Routes { get; set; } = new List<Route>();
    }
}
