using Microsoft.AspNetCore.Mvc;
using Proyect_alfabet_7._0.Models;
using Proyect_alfabet_7._0.Repository;
using System.Diagnostics;

namespace Proyect_alfabet_7._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogin _loginUser;

        public HomeController(ILogin loguser)
        {
            _loginUser = loguser;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string passcode)
        {
            var isuccess = _loginUser.AuthenticateUser(username, passcode);

            if(isuccess.Result != null)
            {
                ViewBag.username = string.Format("Ingreso correcto", username);

                TempData["username"] = "Ahmed";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.username = string.Format("Ingreso fallido", username);
                return View();
            }
        }

    
        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
        }*/
    }
}