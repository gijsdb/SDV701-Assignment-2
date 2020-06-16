using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

/*
    Author: Gijs de Blauw
    Description: 
        - The command window that hosts the API on a specified address.
*/

namespace sdv701_selfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure server
            Uri _baseAddress = new Uri("http://localhost:60064/");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);
            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
            );
            // Create server
            HttpSelfHostServer server = new HttpSelfHostServer(config);
            // Start server
            server.OpenAsync().Wait();
            Console.WriteLine("CameraCo server is live on " + _baseAddress);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
            server.CloseAsync().Wait();
        }
    }
}
