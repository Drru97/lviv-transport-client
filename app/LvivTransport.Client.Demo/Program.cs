using System;
using LvivTransport.Client.Core;
using LvivTransport.Client.Core.Request;

namespace LvivTransport.Client.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // getting the client
            var client = new LvivTransportService();

            // creating request for getting all routes
            var routesRequest = new RoutesRequest();

            // getting the routes
            var routes = client.GetResponse(routesRequest);

            // creating request for getting stop with id = 18
            var stopRequest = new StopsRequest(18);

            // getting specified stop
            var stop = client.GetResponse(stopRequest);

            // disposing resources
            client.Dispose();

            Console.ReadKey();
        }
    }
}
