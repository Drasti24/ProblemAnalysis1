//DRASTI PATEL (#8839416)
//PROBLEM ANALYSIS #1
//FEBRUARY 16, 2025


using DatePickerHint.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DatePickerHint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //constructor to initialize logger for logging purposes.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //index method - responsible for rendering the home page.
        //typically the default landing page of app.
        public IActionResult Index()
        {
            return View();          //renders Index view
        }

        //privacy method - renders a page for displaying privacy policy or related content.
        public IActionResult Privacy()
        {
            return View();      //renders the Privacy view.
        }

        //error method - handles error situations in the app.
        //it uses the ResponseCache attribute to disable caching fot the error page.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //passes the request ID or trace identifier to ErrorViewModel for debugging.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
