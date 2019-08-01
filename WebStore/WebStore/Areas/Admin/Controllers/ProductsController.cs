using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStore.Areas.Admin.Models.ViewModels;
using WebStore.Models.Data;

namespace WebStore.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products
        public ActionResult Index()
        {
            List<Product> list;

            using (StoreDbContext db = new StoreDbContext())
            {
                list = db.Products.Include("Category").ToList();
            }

            return View(list);
        }

        // GET: Admin/Products/Create
        [HttpGet]
        public ActionResult Create()
        {
            SelectList categories;
            using (StoreDbContext db = new StoreDbContext())
            {
                categories = new SelectList(db.ProductCategories.ToList(), "Id", "Name");
            }
            ViewBag.Categories = categories;

            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            Product newProduct = new Product(productViewModel);
            using (StoreDbContext db = new StoreDbContext())
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Products/Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product;
            SelectList categories;
            using (StoreDbContext db = new StoreDbContext())
            {
                product = db.Products.Find(id);
                db.Entry(product).Reference(p => p.Category).Load();

                categories = new SelectList(db.ProductCategories.ToList(), "Id", "Name");
            }
            ViewBag.Categories = categories;

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(new ProductViewModel(product));
            }
        }

        // POST: Admin/Products/Edit
        [HttpPost]
        public ActionResult Edit(ProductViewModel editedProduct)
        {
            Product originalProduct;
            SelectList categories;
            using (StoreDbContext db = new StoreDbContext())
            {
                originalProduct = db.Products.Find(editedProduct.Id);
                if (originalProduct == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    originalProduct.Name = editedProduct.Name;
                    originalProduct.Price = (new Product(editedProduct)).Price;
                    originalProduct.Quantity = editedProduct.Quantity;
                    originalProduct.CategoryId = editedProduct.CategoryId;

                    db.SaveChanges();
                }

                categories = new SelectList(db.ProductCategories.ToList(), "Id", "Name");
            }
            ViewBag.Categories = categories;

            return View(editedProduct);
        }

        // GET: Admin/Products/Remove
        public ActionResult Remove(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (StoreDbContext db = new StoreDbContext())
            {
                if (db.Products.Remove(db.Products.Find(id)) != null)
                {
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}