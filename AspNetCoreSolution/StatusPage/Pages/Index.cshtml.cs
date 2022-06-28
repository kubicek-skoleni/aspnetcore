using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StatusPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _context;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string APIStatus { get; set; }
        public string DBStatus { get; set; }

        public int PeopleCount { get; set; }

        public void OnGet()
        {
            CheckWebApi();
            CheckDatabase();
        }

        private void CheckDatabase()
        {
            try
            {
                PeopleCount = _context.Persons.Count();
                DBStatus = "OK";
            }
            catch
            {
                DBStatus = "NOT OK";
            }
        }

        private void CheckWebApi()
        {
            var api_url = "https://localhost:7192/api/health";
            var client = new HttpClient();

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