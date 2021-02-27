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
        
        public ActionResult Manager()
        {
            var products = context.Products
                .OrderBy(t => t.Name)
                .ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var products = context.Products
                .FirstOrDefault(i => i.ProductId == id);
            return View(products);
        }

        // GET: ProductController/Create
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var product = context.Products
                .FirstOrDefault(i => i.ProductId == id);
            return View(product);
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = context.Products
                .FirstOrDefault(i => i.ProductId == id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                context.Remove(context.Products.Single(i => i.ProductId == product.ProductId));
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
