using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Admin.Integration
{
    public class CoinbaseApiConnector : AdminApiConnector, ICoinbaseApiConnector
    {
        public CoinbaseApiConnector(HttpClient httpClient, ILogger<CoinbaseApiConnector> logger) : base(httpClient, logger, "CoinbaseApi") {}
    }
}