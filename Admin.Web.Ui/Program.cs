using Hub.Web.HostBuilder;
using Microsoft.Extensions.Hosting;

namespace Admin.Web.Ui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder<Startup, DependencyRegistrationFactory>().CreateHostBuilder(args).Build().Run();
        }
    }
}