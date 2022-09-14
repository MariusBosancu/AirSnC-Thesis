using AirSnC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace AirSnC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(SignInDbContext context,ProductsDbContext context1)
        {
            _context = context;
            _context1 = context1;
            //ViewBag.name = TempData["name"];
        }
        
        public IActionResult Index()
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Maps()
        {
            return View();
        }
        
        
        public IActionResult LogIn() { return View(); }
        public IActionResult LogOut() 
        {
            HttpContext.Session.Clear();
            ViewBag.name = null;
            return RedirectToAction("Index");
        }
        private readonly SignInDbContext _context;
        private readonly ProductsDbContext _context1;
        //private readonly ProductsDbContext _context;

        public IActionResult alertss(string id) 
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            ViewBag.Message = string.Format("Hello {0}.\\n Your order : {1} is on your way.", ViewBag.name , id.ToString());
            return View();
        }
        public ViewResult ProductView(string search,int p = 1)
        {

            ViewBag.name = HttpContext.Session.GetString("user");
            //ViewBag.cakes = TempData["cakes"];
            //var searchString = ViewBag.cakes;

            if (search != null)
            {
                var Cakes = from s in this._context1.Productss select s;
                if (!String.IsNullOrEmpty(search))
                {
                    string[] words = search.Split(' ');
                    foreach (var word in words)
                    {
                        Cakes = Cakes.Where(s => s.Name.Contains(word)
                                            || s.Price.Contains(word)
                                            || s.Description.Contains(word)
                                            
                                            );
                    }
                }
                Cakes = Cakes.OrderByDescending(s => s.Name);
                ViewData["pl"] = Cakes;

                PagedResult<Products> Cakess = Cakes.GetPaged(1, 6);
                return View(Cakess);
            }
            else
            {
                PagedResult<Products> Items = this._context1.Productss.GetPaged(p, 6);
                return View(Items);
            }

            
        }

        public async Task<IActionResult> Product(string id)
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            if (id == null || _context1.Productss == null)
            {
                return NotFound();
            }

            var products = await _context1.Productss
                .FirstOrDefaultAsync(m => m.Name == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }
        public IActionResult SignUp()
        {
            return View();
        }
        
        
        
        public IActionResult SignUpB(string Username , string UserType , string Password , string Email)
        {
            SignInDbContext SignIn = Models.SignInDbContext.singIn;
            if (ModelState.IsValid)
            {
                _context.Add(SignIn);
                _context.SaveChangesAsync();
               
                return View("Index");
            }
            return View(SignIn);
        }
        public IActionResult admin() 
        {
            ViewBag.name = HttpContext.Session.GetString("user");
            return View(); 
        }
        
        [HttpGet]
        public IActionResult LogIn(string username , string password)
        {
            if (username == null) {
                username = "";
                password = "";
            }
            var query = _context.SingIns
                .Where(m => m.Password == password);
            var querystring = query.ToQueryString();
            var result = query.FirstOrDefault();
            if (result != null)
            {
                if (result.UserType == "A")
                {
                    
                    HttpContext.Session.SetString("user", result.Username.ToString());
                    ViewBag.name = HttpContext.Session.GetString("user");
                    return RedirectToAction("admin"); 
                }
                else {
                    
                    HttpContext.Session.SetString("email", result.Email.ToString());
                    HttpContext.Session.SetString("user", result.Username.ToString());
                    ViewBag.name = HttpContext.Session.GetString("user");
                    return RedirectToAction("ProductView");
                }
                
                
            }
            else { ModelState.AddModelError("username", "Username or password are wrong!"); return View(); };
        }
        

    //public async Task<IActionResult> ProductView()
    //{
    //    return _context3.Productss != null ?
    //                View(await _context3.Productss.ToListAsync()) :
    //                Problem("Entity set 'SignInDbContext.SingIns'  is null.");
    //}


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}