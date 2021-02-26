using SportsSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Controllers
{
    public class CustomerController : Controller
    {
        private SportingContext context { get; set; }

        public CustomerController(SportingContext ctxt)
        {
            context = ctxt;
        }
        public IActionResult Manager()
        {
            var customers = context.Customers
                .Include(c => c.Country)
                .OrderBy(c => c.FirstName)
                .ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Value = "Submit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            return View("Add_Edit" , new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Value = "Apply";
            ViewBag.Id = id;
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();

            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);
            return View("Add_Edit" , customer);

        }

        [HttpPost]
        public IActionResult Add_Edit(Customer customer, int id)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = id;
                string action = (customer.CustomerId == 0) ? "Add" : "Edit";
                if (action == "Add")
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("Manager", "Customer");
            }
            else
            {
                ViewBag.Action = "Add";
                ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers
                .Include(c => c.Country)
                .FirstOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer , int id)
        {
            context.Remove(context.Customers.Single(c => c.CustomerId == id));
            context.SaveChanges();
            return RedirectToAction("Manager", "Customer");
        }
    }
}
