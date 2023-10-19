using System;
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
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Acción asincrónica que recibe un id de usuario y crea una lista con los mensajes recibidos y enviados.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Messages
        public async Task<IActionResult> Index(int id)
        {
            ViewData["id"] = id;
            List<Message> receivedMessages = await _context.Messages
                .Where(r => r.ReceiverId == id)
                .OrderByDescending(r => r.Id)
                .ToListAsync();

            List<Message> sentMessages = await _context.Messages
                .Where(s => s.SenderId == id)
                .OrderByDescending(s => s.Id)
                .ToListAsync();

            var viewModel = new MessageViewModel
            {
                ReceivedMessages = receivedMessages,
                SentMessages = sentMessages
            };
            return View(viewModel);
        }

        /// <summary>
        /// No en uso.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .Include(m => m.Receiver)
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        /// <summary>
        /// Acción GET para la creación de mensajes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Messages/Create
        public IActionResult Create(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        /// <summary>
        /// Acción POST para la creación de mensajes. Recibe la información del receptor y el mensaje. Se busca el id según el nombre de usuario y muestra el mensaje de error o de envío correcto según corresponda.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,Content,SenderId,SenderName,ReceiverId,ReceiverName")] Message message)
        {
            ViewData["id"] = id;
            if (ModelState.IsValid)
            {
                var sender = await _context.UserLogin.FirstOrDefaultAsync(s => s.Id == message.SenderId);
                if (sender != null) { message.SenderName = sender.UserName; }
                var receiver = await _context.UserLogin.FirstOrDefaultAsync(u => u.UserName == message.ReceiverName);
                if (receiver != null)
                {
                    message.ReceiverId = receiver.Id;
                    if (message.Id == message.ReceiverId)
                    {
                        ModelState.AddModelError(string.Empty, "No se puede enviar mensajes a uno mismo");
                        return View();
                    }
                    else
                    {
                        _context.Add(message);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("IndexCreate", new {@id =message.SenderId });
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario inexistente");
                    return View();
                }
            }
            return View();
        }

        /// <summary>
        /// Acción para la vista de mensaje enviado correctamente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult IndexCreate(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Discriminator", message.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Discriminator", message.SenderId);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,SenderId,ReceiverId")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
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
            ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "Discriminator", message.ReceiverId);
            ViewData["SenderId"] = new SelectList(_context.Users, "Id", "Discriminator", message.SenderId);
            return View(message);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var message = await _context.Messages
                .Include(m => m.Receiver)
                .Include(m => m.Sender)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Messages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Messages'  is null.");
            }
            var message = await _context.Messages.FindAsync(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
          return (_context.Messages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
