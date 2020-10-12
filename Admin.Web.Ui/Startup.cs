using Hub.Web.Startup;
using Microsoft.Extensions.Configuration;

namespace Admin.Web.Ui
{
    public class Startup : WebStartup<DependencyRegistrationFactory>
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
    }
}