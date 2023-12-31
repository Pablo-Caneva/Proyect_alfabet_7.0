﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;

namespace Proyect_alfabet_7._0.Controllers
{
    public class UserLoginsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserLoginsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserLogins
        public async Task<IActionResult> Index()
        {
            return _context.Users != null ? 
                          View(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.UserLogin'  is null.");
        }

        // GET: UserLogins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserLogin == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }

        // GET: UserLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLogin);
        }

        // GET: UserLogins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password")] UserLogin userLogin)
        {
            if (id != userLogin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLoginExists(userLogin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userLogin);
        }

        // GET: UserLogins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserLogin == null)
            {
                return NotFound();
            }

            var userLogin = await _context.UserLogin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userLogin == null)
            {
                return NotFound();
            }

            return View(userLogin);
        }

        // POST: UserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserLogin == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserLogin'  is null.");
            }
            var userLogin = await _context.UserLogin.FindAsync(id);
            if (userLogin != null)
            {
                _context.UserLogin.Remove(userLogin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLoginExists(int id)
        {
          return (_context.UserLogin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
