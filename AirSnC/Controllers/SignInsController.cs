using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirSnC.Models;
using System.Diagnostics.Eventing.Reader;
using System.Net.Mail;
using System.Net;

namespace AirSnC.Controllers
{
    public class SignInsController : Controller
    {
        private readonly SignInDbContext _context;

        public SignInsController(SignInDbContext context)
        {
            _context = context;
        }
       public IActionResult Recpass()
        { return View(); }
        public bool Recoverpassword(string email)
        {
            //ViewBag.email = HttpContext.Session.GetString("email");
            
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            message.From = new MailAddress("marius.bosancu.mb@gmail.com");
            message.To.Add(email);
            var query = _context.SingIns
                .Where(m => m.Email == email);
            var querystring = query.ToQueryString();
            var result = query.FirstOrDefault();

            message.Subject = "Your password";
            message.IsBodyHtml = true;
            message.Body = "<p> Your password is : "+ result.Password + "</p>";
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("marius.bosancu.mb@gmail.com", "password here");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(message);
            return true;
        }
        // GET: SignIns
        public async Task<IActionResult> Index()
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            return _context.SingIns != null ? 
                          View(await _context.SingIns.ToListAsync()) :
                          Problem("Entity set 'SignInDbContext.SingIns'  is null.");
        }

        // GET: SignIns/Details/5
        public async Task<IActionResult> Details(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id == null || _context.SingIns == null)
            {
                return NotFound();
            }

            var signIn = await _context.SingIns
                .FirstOrDefaultAsync(m => m.Username == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // GET: SignIns/Create
        public IActionResult Create()
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            return View();
        }

        // POST: SignIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,UserType,Password,Email")] SignIn signIn)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (ModelState.IsValid)
            {
                _context.Add(signIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signIn);
        }

        // GET: SignIns/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id == null || _context.SingIns == null)
            {
                return NotFound();
            }

            var signIn = await _context.SingIns.FindAsync(id);
            if (signIn == null)
            {
                return NotFound();
            }
            return View(signIn);
        }

        // POST: SignIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserName,UserType,Password,Email")] SignIn signIn)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id != signIn.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignInExists(signIn.Username))
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
            return View(signIn);
        }

        // GET: SignIns/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id == null || _context.SingIns == null)
            {
                return NotFound();
            }

            var signIn = await _context.SingIns
                .FirstOrDefaultAsync(m => m.Username == id);
            if (signIn == null)
            {
                return NotFound();
            }

            return View(signIn);
        }

        // POST: SignIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (_context.SingIns == null)
            {
                return Problem("Entity set 'SignInDbContext.SingIns'  is null.");
            }
            var signIn = await _context.SingIns.FindAsync(id);
            if (signIn != null)
            {
                _context.SingIns.Remove(signIn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignInExists(string id)
        {
          return (_context.SingIns?.Any(e => e.Username == id)).GetValueOrDefault();
        }
    }
}
