using SportsSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [Route("Incidents")]
        public ViewResult Manager(string Filter = "")
        {
            IncidentListViewModel vm = new IncidentListViewModel();
            
            if(Filter == "unassigned")
            {
                vm.Incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Where(i => i.Technician == null)
                .OrderBy(i => i.IncidentId)
                .ToList();
                ViewBag.All = "";
                ViewBag.Un = "active";
                ViewBag.Open = "";
            }
            else if(Filter == "openincident")
            {
                vm.Incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Where(i => i.DateClosed == null)
                .OrderBy(i => i.IncidentId)
                .ToList();
                ViewBag.All = "";
                ViewBag.Un = "";
                ViewBag.Open = "active";
            }
            else
            {
                vm.Incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .OrderBy(i => i.IncidentId)
                .ToList();
                ViewBag.All = "active";
                ViewBag.Un = "";
                ViewBag.Open = "";
            }
            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpGet]
        public ViewResult Add()
        {
            IncidentEditViewModel vm = new IncidentEditViewModel();
            vm.Action = "Add";
            vm.Products = new SelectList(context.Products.OrderBy(c => c.Name).ToList(), "ProductId", "Name");
            vm.Customers = new SelectList(context.Customers.OrderBy(c => c.FirstName).ToList(), "CustomerId", "FirstName");
            vm.Technicians = new SelectList(context.Technicians.OrderBy(c => c.Name).ToList(), "TechnicianId", "Name");
            vm.Incident = new Incident();
            return View("Edit", vm);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            IncidentEditViewModel vm = new IncidentEditViewModel();
            vm.Action = "Add";
            vm.Products = new SelectList(context.Products.OrderBy(c => c.Name).ToList(), "ProductId", "Name");
            vm.Customers = new SelectList(context.Customers.OrderBy(c => c.FirstName).ToList(), "CustomerId", "FullName");
            vm.Technicians = new SelectList(context.Technicians.OrderBy(c => c.Name).ToList(), "TechnicianId", "Name");

            vm.Incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(vm);
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
                    TempData["message"] = $"\"{incident.Title}\" incident is {action}ed Successfully";
                    return RedirectToAction("Manager");
                }
                else
                {
                    IncidentEditViewModel vm = new IncidentEditViewModel();
                    vm.Action = action;
                    vm.Products = new SelectList(context.Products.OrderBy(c => c.Name).ToList(), "ProductId", "Name");
                    vm.Customers = new SelectList(context.Customers.OrderBy(c => c.FirstName).ToList(), "CustomerId", "FullName");
                    vm.Technicians = new SelectList(context.Technicians.OrderBy(c => c.Name).ToList(), "TechnicianId", "Name");
                    vm.Incident = incident;
                    return View(vm);
                }
            }
            catch
            {
                IncidentEditViewModel vm = new IncidentEditViewModel();
                vm.Action = action;
                vm.Products = new SelectList(context.Products.OrderBy(c => c.Name).ToList(), "ProductId", "Name");
                vm.Customers = new SelectList(context.Customers.OrderBy(c => c.FirstName).ToList(), "CustomerId", "FullName");
                vm.Technicians = new SelectList(context.Technicians.OrderBy(c => c.Name).ToList(), "TechnicianId", "Name");
                vm.Incident = incident;
                return View(vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var incident = context.Incidents
                .FirstOrDefault(i => i.IncidentId == id);
            return View(incident);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Delete(Incident incident)
        {
            try
            {
                context.Remove(context.Incidents.Single(i => i.IncidentId == incident.IncidentId));
                context.SaveChanges();
                TempData["message"] = $"\"{incident.Title}\" incident is Deleted Successfully";
                return RedirectToAction("Manager");
            }
            catch
            {
                TempData["message"] = $"\"{incident.Title}\" incident deletion Failed";
                return RedirectToAction("Manager");
            }
        }
    }
}
