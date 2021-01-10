using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Admin.Integration
{
    public class CoinbaseProApiConnector : AdminApiConnector, ICoinbaseProApiConnector
    {
        public CoinbaseProApiConnector(HttpClient httpClient) : base(httpClient, "CoinbaseProApi") {}
    }
}