using Microsoft.AspNetCore.Hosting;

namespace NetCoreSaaS.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                            .UseUrls("http://*.localhost:6001")
                            .UseStartup<Startup>()
                            .Build();
        }
    }

}
