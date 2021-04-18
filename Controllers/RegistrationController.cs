using SportsSoft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Controllers
{
    public class RegistrationController : Controller
    {
        private SportingContext context { get; set; }

        public RegistrationController(SportingContext ctx)
        {
            context = ctx;
        }

        [Route("Registrations")]
        public IActionResult Get()
        {
            ViewBag.Customers = new SelectList(context.Customers.OrderBy(t => t.FirstName).ToList(), "CustomerId", "FirstName");
            return View(new Customer());
        }

        public IActionResult List(Customer cs)
        {
            if(cs.CustomerId > 0)
            {
                ViewBag.Registrations = context.Registrations.Include(p => p.Product).Where(c => c.CustomerId == cs.CustomerId).ToList();
                ViewBag.Name = context.Customers.FirstOrDefault(c => c.CustomerId == cs.CustomerId).FullName;
                ViewBag.Products = new SelectList(context.Products.OrderBy(p => p.Name).ToList(), "ProductId", "Name");
                return View(new Product());
            }
            else
            {
                return RedirectToAction("Get");
            }
        }
    }
}
