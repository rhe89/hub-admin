using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Admin.Integration
{
    public class SpreadsheetApiConnector : AdminApiConnector, ISpreadsheetApiConnector
    {
        public SpreadsheetApiConnector(HttpClient httpClient, ILogger<SpreadsheetApiConnector> logger) : base(httpClient, logger, "SpreadsheetApi") {}
    }
}