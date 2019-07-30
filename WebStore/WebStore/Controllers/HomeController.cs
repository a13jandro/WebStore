using System.Web.Mvc;
using System.Linq;

using System.Collections.Generic;

using WebStore.Models.Data;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (StoreDbContext db = new StoreDbContext())
            {
                ProductCategory category = db.ProductCategories.First(x => x.Name == "Food");

                string output = "";
                foreach (ProductCategory subcategory in category.Subcategories)
                {
                    output += subcategory.Name;
                }

                ViewBag.Output = output;
            }
            return View();
        }
    }
}