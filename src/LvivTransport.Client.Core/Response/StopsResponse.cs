using System.Collections.Generic;
using LvivTransport.Client.Core.Abstract;
using LvivTransport.Client.Core.Models;

namespace LvivTransport.Client.Core.Response
{
    public class StopsResponse : ServiceResponse
    {
        public ICollection<Stop> Stops { get; set; } = new List<Stop>();
    }
}
