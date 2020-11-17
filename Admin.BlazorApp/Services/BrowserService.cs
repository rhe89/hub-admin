using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Admin.BlazorApp.Services
{
    public class BrowserService
    {
        private readonly IJSRuntime _js;
        
        public BrowserService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<bool> IsDesktop()
        {
            var browserDimensions = await GetDimensions();

            return browserDimensions.Width > 1200;
        }

        public async Task<BrowserDimension> GetDimensions()
        {
            return await _js.InvokeAsync<BrowserDimension>("getDimensions");
        }

    }

    public class BrowserDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}