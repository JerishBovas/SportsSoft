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

        [Route("Technicians")]
        public ViewResult Manager()
        {
            var technician = context.Technicians
                .OrderBy(t => t.Name)
                .ToList();
            return View(technician);
        }

        
        public ViewResult Details(int id)
        {
            var technician = context.Technicians
                .FirstOrDefault(i => i.TechnicianId == id);
            return View(technician);
        }

        
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        
        public ViewResult Edit(int id)
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
                    TempData["message"] = $"\"{technician.Name}\" Technician is {action}ed Successfully";
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

        public ViewResult Delete(int id)
        {
            var technician = context.Technicians
                .FirstOrDefault(i => i.TechnicianId == id);
            return View(technician);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Delete(Technician technician)
        {
            try
            {
                context.Remove(context.Technicians.Single(i => i.TechnicianId == technician.TechnicianId));
                context.SaveChanges();
                TempData["message"] = $"\"{technician.Name}\" Technician is Deleted Successfully";
                return RedirectToAction("Manager");
            }
            catch
            {
                TempData["message"] = $"\"{technician.Name}\" Technician Deletion Failed";
                return RedirectToAction("Manager");
            }
        }
    }
}
