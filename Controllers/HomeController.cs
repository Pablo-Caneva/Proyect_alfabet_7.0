using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;
using Proyect_alfabet_7._0.Repository;
using System.Diagnostics;

namespace Proyect_alfabet_7._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogin _loginUser;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogin loginUser, ApplicationDbContext context)
        {
            _loginUser = loginUser;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string passcode)
        {
            var isuccess = _loginUser.AuthenticateUser(username, passcode);


            if (isuccess.Result != null)
            {
                string? discriminator = _context.UserLogin
                    .Where(u => u.Id == isuccess.Result.Id)
                    .Select(u => EF.Property<string>(u, "Discriminator"))
                    .FirstOrDefault();

                if (discriminator != null)
                {
                    if (discriminator == "Student")
                    {
                        return RedirectToAction("IndexStudent", "Menu");
                    }
                    if (discriminator == "Tutor")
                    {
                        return RedirectToAction("IndexTutor", "Menu");
                    }
                    if (discriminator == "Admin")
                    {
                        return RedirectToAction("IndexAdmin", "Menu");
                    }
                    return View();
                }
                else { return View(); }
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