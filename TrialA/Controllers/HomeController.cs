using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrialA.Data;
using TrialA.Models;

namespace TrialA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _appDBContext;

        public HomeController(ILogger<HomeController> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> sendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                _appDBContext.Messages.Add(message);
                await _appDBContext.SaveChangesAsync();
                return View(message);
            }
            return View();
        }
    }
}
