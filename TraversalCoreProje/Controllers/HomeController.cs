using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index sayfasý çaðýrýldý.");
            _logger.LogError("Error log çaðýrýldý");
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime dateTime = Convert.ToDateTime(DateTime.Now);
            _logger.LogInformation(dateTime + " Privacy sayfasý çaðýrýldý."); 
            return View();
        }

        public IActionResult Test()
        {
            _logger.LogInformation("Test sayfasý çaðýrýldý");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
