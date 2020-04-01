using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManitowocCoffeeCompany.Models;

namespace ManitowocCoffeeCompany.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            using(MCCContext context = new MCCContext())
            {
                var list = context.Products.OrderBy(x => x.Price).ToList();
                return View(list);
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using(MCCContext context = new MCCContext())
            {
                Product p = context.Products.Find(id);
                return View(p);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product obj)
        {
            try
            {
                using(MCCContext context = new MCCContext())
                {
                    context.Products.Add(obj);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product result = null;
            using(MCCContext context = new MCCContext())
            {
                result = context.Products.Find(id);
                return View(result);
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using(MCCContext context = new MCCContext())
                {
                    var p = context.Products.Find(id);
                    TryUpdateModel(p);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product result = null;
            using (MCCContext context = new MCCContext())
            {
                result = context.Products.Find(id);
                return View(result);
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (MCCContext context = new MCCContext())
                {
                    var p = context.Products.Find(id);
                    context.Products.Remove(p);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
