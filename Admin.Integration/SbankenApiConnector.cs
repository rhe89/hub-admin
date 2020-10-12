using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Admin.Integration
{
    public class SbankenApiConnector : AdminApiConnector, ISbankenApiConnector
    {
        public SbankenApiConnector(HttpClient httpClient, ILogger<SbankenApiConnector> logger) : base(httpClient, logger, "SbankenApi") {}
    }
}