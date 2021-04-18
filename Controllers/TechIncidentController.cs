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
    public class TechIncidentController : Controller
    {
        private SportingContext context { get; set; }

        public TechIncidentController(SportingContext ctx)
        {
            context = ctx;
        }

        public IActionResult Get()
        {
            var sess = new TechnicianSession(HttpContext.Session);
            var technician = sess.GetTechnician();
            if(technician != null)
            {
                RedirectToAction("List", technician);
            }
            technician = new Technician();
            ViewBag.Technicians = new SelectList(context.Technicians.OrderBy(t => t.Name).ToList(), "TechnicianId", "Name");
            return View(technician);
        }

        [HttpPost]
        public IActionResult List(Technician ti)
        {
            if (ti.TechnicianId > 0)
            {
                var Incidents = context.Incidents
                    .Include(i => i.Customer)
                    .Include(i => i.Product)
                    .Where(i => i.TechnicianId == ti.TechnicianId)
                    .Where(i => i.DateClosed == null)
                    .ToList();
                ViewBag.Technician = context.Technicians.FirstOrDefault(t => t.TechnicianId == ti.TechnicianId);
                var sess = new TechnicianSession(HttpContext.Session);
                sess.SetTechnician(ViewBag.Technician);
                return View(Incidents);
            }
            else
            {
                TempData["message"] = "Please select a Technician and Continue";
                return RedirectToAction("Get");
            }
        }

        public IActionResult Edit(int id)
        {
            var Incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentId == id);
            return View(Incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();
                TempData["message"] = $"\"{incident.Title}\" incident is Edited Successfully";
                return RedirectToAction("Get");
            }
            else
            {
                return View(incident);
            }
        }
    }
}
