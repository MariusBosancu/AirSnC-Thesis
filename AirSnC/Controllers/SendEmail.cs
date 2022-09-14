using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System.Net.Mail;
using AirSnC.Models;
using Microsoft.EntityFrameworkCore;

namespace AirSnC.Controllers
{
    public class SendEmail : Controller
    {
        public IActionResult Index( )
        {
            //ViewBag.name = HttpContext.Session.GetString("user");
            
            return View();
        }
        private readonly SignInDbContext _context;
        
        
        //    public ActionResult OrderNow(int id)
        //    {
        //        Session["cart"] = 0;
        //        if (Session["cart"] == null)
        //        {
        //            List<Item> cart = new List<Item>();

        //            cart.Add(new Item(alo.Cars.Find(id), 1)); // Add 1 Product based on id provided

        //            Session["cart"] = cart; // Update Session["cart"]
        //        }
        //        else
        //        {
        //            List<Item> cart = (List<Item>)Session["cart"];

        //            int index = isExisting(id); // index = Product ID from in the Cart only

        //            if (index == -1) // If the product to be order is not already in the cart

        //                cart.Add(new Item(alo.Cars.Find(id), 1)); // Add 1 Product based on id provided

        //            else // if product already exists in the cart

        //                cart[index].Quantity++; // increase the quantity of the product based on the ID provided

        //            Session["cart"] = cart; // Update Session["cart"]
        //        }

        //        return View("Cart");
        //    }
        //}
    }
}
