using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Emails")]
        public IActionResult Emails()
        {
            List<string> model = new List<string>() 
            {
                "example@example.com",
                "pokus@pokus.cz"
            };

            ViewData["extra"] = "Stav";
            return View(model);
        }
    }
}
