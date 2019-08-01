using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models.Data
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<ProductCategory> Subcategories { get; set; }
        public int? SupecategoryId { get; set; }
        public virtual ProductCategory Supercategory { get; set; }

        public virtual List<Product> Products { get; set; }

        public ProductCategory()
        {
            Subcategories = new List<ProductCategory>();
            Products = new List<Product>();
        }
    }
}