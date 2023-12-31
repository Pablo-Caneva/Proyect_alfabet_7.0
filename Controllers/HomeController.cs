﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Tarea asincrónica que diferencia el menú a mostrar según el tipo de usuario.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="passcode"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(string username, string passcode)
        {
            var isuccess = await _loginUser.AuthenticateUser(username, passcode);

            if (isuccess != null)
            {
                int? userId = isuccess.Id;
                string? discriminator = await _context.UserLogin
                    .Where(u => u.Id == isuccess.Id)
                    .Select(u => EF.Property<string>(u, "Discriminator"))
                    .FirstOrDefaultAsync();

                if (discriminator != null)
                {
                    if (discriminator == "Student")
                    {
                        return RedirectToAction("IndexStudent", "Menu", new { @id = userId } );
                    }
                    if (discriminator == "Tutor")
                    {
                        return RedirectToAction("IndexTutor", "Menu", new { @id = userId });
                    }
                    if (discriminator == "Admin")
                    {
                        return RedirectToAction("IndexAdmin", "Menu", new { @id = userId });
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

        /// <summary>
        /// No en uso actualmente. Acción para envío correcto de email de recuperación de pass.
        /// </summary>
        /// <returns></returns>
        public IActionResult EmailSent()
        {
            return View();
        }

        /// <summary>
        /// No en uso actualmente. Acción para email erróneo de recuperación de pass.
        /// </summary>
        /// <returns></returns>
        public IActionResult EmailError()
        {
            return View();
        }

        /// <summary>
        /// No en uso actualmente. Acción para email inexistente de recuperación de pass.
        /// </summary>
        /// <returns></returns>
        public IActionResult EmailInex()
        {
            return View();
        }
    }
}