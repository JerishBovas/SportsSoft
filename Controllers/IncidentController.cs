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
    public class IncidentController : Controller
    {
        private SportingContext context { get; set; }

        public IncidentController(SportingContext ctx)
        {
            context = ctx;
        }

        public IActionResult Manager()
        {
            var incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .OrderBy(i => i.IncidentId)
                .ToList();
            return View(incidents);
        }

        public ActionResult Details(int id)
        {
            var incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Products = context.Products.OrderBy(c => c.Name).ToList();
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(c => c.Name).ToList();
            return View("Edit", new Incident());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Products = context.Products.OrderBy(c => c.Name).ToList();
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(c => c.Name).ToList();

            var incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Incident incident)
        {
            string action = (incident.IncidentId == 0) ? "Add" : "Edit";

            try
            {
                if (ModelState.IsValid)
                {
                    if (action == "Add")
                    {
                        if(incident.DateOpened == null)
                        {
                            incident.DateOpened = DateTime.Now;
                        }
                        context.Incidents.Add(incident);
                    }
                    else
                    {
                        context.Incidents.Update(incident);
                    }
                    context.SaveChanges();
                    return RedirectToAction("Manager");
                }
                else
                {
                    ViewBag.Action = action;
                    ViewBag.Products = context.Products.OrderBy(c => c.Name).ToList();
                    ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
                    ViewBag.Technicians = context.Technicians.OrderBy(c => c.Name).ToList();
                    return View(incident);
                }
            }
            catch
            {
                ViewBag.Action = action;
                ViewBag.Products = context.Products.OrderBy(c => c.Name).ToList();
                ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
                ViewBag.Technicians = context.Technicians.OrderBy(c => c.Name).ToList();
                return View(incident);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var incident = context.Incidents
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Incident incident)
        {
            try
            {
                context.Remove(context.Incidents.Single(i => i.IncidentId == incident.IncidentId));
                context.SaveChanges();
                return RedirectToAction("Manager");
            }
            catch
            {
                return RedirectToAction("Manager");
            }
        }
    }
}
