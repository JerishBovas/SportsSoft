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
    public class TechnicianController : Controller
    {
        private SportingContext context { get; set; }

        public TechnicianController(SportingContext ctx)
        {
            context = ctx;
        }
        
        public ActionResult Manager()
        {
            var technician = context.Technicians
                .OrderBy(t => t.Name)
                .ToList();
            return View(technician);
        }

        
        public ActionResult Details(int id)
        {
            var technician = context.Technicians
                .FirstOrDefault(i => i.TechnicianId == id);
            return View(technician);
        }

        
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var technician = context.Technicians
                .FirstOrDefault(i => i.TechnicianId == id);
            return View(technician);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Technician technician)
        {
            string action = (technician.TechnicianId == 0) ? "Add" : "Edit";

            try
            {
                if (ModelState.IsValid)
                {
                    if (action == "Add")
                    {
                        context.Technicians.Add(technician);
                    }
                    else
                    {
                        context.Technicians.Update(technician);
                    }
                    context.SaveChanges();
                    return RedirectToAction("Manager");
                }
                else
                {
                    ViewBag.Action = action;
                    return View(technician);
                }
            }
            catch
            {
                ViewBag.Action = action;
                return View(technician);
            }
        }

        // GET: TechnicianController/Delete/5
        public ActionResult Delete(int id)
        {
            var technician = context.Technicians
                .FirstOrDefault(i => i.TechnicianId == id);
            return View(technician);
        }

        // POST: TechnicianController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Technician technician)
        {
            try
            {
                context.Remove(context.Technicians.Single(i => i.TechnicianId == technician.TechnicianId));
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
