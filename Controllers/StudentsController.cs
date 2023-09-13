using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyect_alfabet_7._0.Data;
using Proyect_alfabet_7._0.Models;

namespace Proyect_alfabet_7._0.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
              return _context.Students != null ? 
                          View(await _context.Students.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Students'  is null.");
        }

        public IActionResult IndexCreate()
        {
            return View();
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            try
            {
                var profilePic = await _context.ProfilePic
                    .FirstOrDefaultAsync(m => m.UserId == id);
                if (profilePic != null)
                {
                    string pic = Convert.ToBase64String(profilePic.ProfilePictureBytes);
                    ViewData["Pic"] = pic;
                }
            }
            catch (Exception e)
            {
                ViewData["Pic"] = null;
            }
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("City,Email,Phone,ProfilePicture,Id,UserName,Password")] Student student)
        {
            if (ModelState.IsValid)
            {
                var admin = await _context.Admins.FirstOrDefaultAsync();
                byte[]? profilePictureBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    if (student.ProfilePicture != null)
                    {
                        await student.ProfilePicture.CopyToAsync(memoryStream);
                        profilePictureBytes = memoryStream.ToArray();
                    }
                }
                student.TutorId = admin.Id;
                _context.Add(student);
                await _context.SaveChangesAsync();

                Progress progress = new Progress
                {
                    StudentId = student.Id,
                    ModuleId = 1,
                    LessonId = 1
                };
                _context.Add(progress);
                await _context.SaveChangesAsync();

                if (profilePictureBytes != null)
                {
                    ProfilePic profilePic = new ProfilePic
                    {
                        UserId = student.Id,
                        ProfilePictureBytes = profilePictureBytes
                    };
                    _context.Add(profilePic);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(IndexCreate));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("City,Email,Phone,ProfilePicture,Id,UserName,Password,TutorId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                byte[]? profilePictureBytes = null;
                if (student.ProfilePicture != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await student.ProfilePicture.CopyToAsync(memoryStream);
                        profilePictureBytes = memoryStream.ToArray();
                    }
                    
                    var profilePic = _context.ProfilePic.FirstOrDefault(p => p.UserId == student.Id);
                    if (profilePic != null)
                    {
                        profilePic.ProfilePictureBytes = profilePictureBytes;
                        _context.Update(profilePic);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ProfilePic newProfilePic = new ProfilePic
                        {
                            UserId = student.Id,
                            ProfilePictureBytes = profilePictureBytes
                        };
                        _context.Add(newProfilePic);
                        await _context.SaveChangesAsync();
                    }
                }

                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new {@id = student.Id});
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Recover()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string Email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
            if (user != null)
            {
                string body = user.UserName.ToString() + " " + user.Password.ToString();
                try
                {
                    var smtpClient = new SmtpClient("smtp.example.com")
                    {
                        Credentials = new NetworkCredential("mail","pass"),
                        EnableSsl = true,
                    };

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("mail"),
                        Subject = "Recuperación de contraseña.",
                        Body = body,
                    };

                    mailMessage.To.Add(Email);
                    return RedirectToAction("EmailSent", "Home");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("EmailError", "Home");
                }
            }
            return RedirectToAction("EmailInex", "Home");
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
