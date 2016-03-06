using EntityFramework.ModelFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET.MVC.EF.CodeFirst.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            using (StoreModelContainer db = new StoreModelContainer())
            {
                var products = db.ProductSet.ToList();
                return View(products);
            }
        }

        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                using (StoreModelContainer db = new StoreModelContainer())
                {
                    db.ProductSet.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult Edit(int id)
        {
            using (StoreModelContainer db = new StoreModelContainer())
            {
                Product prod = db.ProductSet.Find(id);
                return View(prod);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            using (StoreModelContainer db = new StoreModelContainer())
            {
                Product prod = db.ProductSet.Where(x => x.ProductID == p.ProductID).First();
                prod.Name = p.Name;
                prod.Description = p.Description;
                prod.Price = p.Price;
                db.SaveChanges();
                return RedirectToAction("List");
            }
        }

        public ActionResult Details(int id)
        {
            using (StoreModelContainer db = new StoreModelContainer())
            {
                Product prod = db.ProductSet.Find(id);
                return View(prod);
            }
        }
           


        public ActionResult Delete(int id)
        {
            using (StoreModelContainer db = new StoreModelContainer())
            {
                Product prod = db.ProductSet.Find(id);
                return View(prod);
            }
        }

        [HttpPost]
        public ActionResult Delete(Product p, int id)
        {
            using (StoreModelContainer db = new StoreModelContainer())
            {
                Product prod = db.ProductSet.Find(id);
                db.ProductSet.Remove(prod);
                db.SaveChanges();
                return RedirectToAction("List");
            }
        }
    }
}