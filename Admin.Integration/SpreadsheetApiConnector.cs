using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Admin.Integration
{
    public class SpreadsheetApiConnector : AdminApiConnector, ISpreadsheetApiConnector
    {
        public SpreadsheetApiConnector(HttpClient httpClient) : base(httpClient, "SpreadsheetApi") {}
    }
}