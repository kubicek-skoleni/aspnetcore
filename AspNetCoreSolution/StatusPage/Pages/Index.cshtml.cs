using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StatusPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string APIStatus { get; set; }

        public void OnGet()
        {
            var api_url = "https://localhost:7192/api/health";
            using var client = new HttpClient();

            try
            {
                var result = client.GetStringAsync(api_url).Result;
                if (result == "Healthy")
                    APIStatus = "OK";
                else
                    APIStatus = "NOT OK";
            }
            catch
            {
                APIStatus = "NOT OK";
            }
        }
    }
}