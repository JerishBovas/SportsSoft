using SportsSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Controllers
{
    public class ProductController : Controller
    {
        private SportingContext context { get; set; }

        public ProductController(SportingContext ctx)
        {
            context = ctx;
        }

        [Route("Products")]
        public ViewResult Manager()
        {
            var products = context.Products
                .OrderBy(t => t.Name)
                .ToList();
            return View(products);
        }

        public ViewResult Details(int id)
        {
            var products = context.Products
                .FirstOrDefault(i => i.ProductId == id);
            return View(products);
        }

        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var product = context.Products
                .FirstOrDefault(i => i.ProductId == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            string action = (product.ProductId == 0) ? "Add" : "Edit";

            try
            {
                if (ModelState.IsValid)
                {
                    if (action == "Add")
                    {
                        context.Products.Add(product);
                    }
                    else
                    {
                        context.Products.Update(product);
                    }
                    context.SaveChanges();
                    TempData["message"] = $"\"{product.Name}\" Product is {action}ed Successfully";
                    return RedirectToAction("Manager");
                }
                else
                {
                    ViewBag.Action = action;
                    return View(product);
                }
            }
            catch
            {
                ViewBag.Action = action;
                return View(product);
            }
        }

        public ViewResult Delete(int id)
        {
            var product = context.Products
                .FirstOrDefault(i => i.ProductId == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Delete(Product product)
        {
            try
            {
                context.Remove(context.Products.Single(i => i.ProductId == product.ProductId));
                context.SaveChanges();
                TempData["message"] = $"\"{product.Name}\" Product is Deleted Successfully";
                return RedirectToAction("Manager");
            }
            catch
            {
                TempData["message"] = $"\"{product.Name}\" Product Deletion Failed";
                return RedirectToAction("Manager");
            }
        }
    }
}
