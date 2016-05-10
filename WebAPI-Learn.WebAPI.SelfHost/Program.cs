namespace WebAPI_Learn.WebAPI.SelfHost
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mime;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Http.SelfHost;

    class Program
    {
        static void Main(string[] args)
        {
            Assembly.Load("WebAPI-Learn.WebAPI");
            HttpSelfHostConfiguration config = new HttpSelfHostConfiguration("http://localhost/selfhost");
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.Configuration.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });
                server.OpenAsync();
                Console.WriteLine("http://localhost/selfhost");
                Console.Read();
            }
        }
    }
}
