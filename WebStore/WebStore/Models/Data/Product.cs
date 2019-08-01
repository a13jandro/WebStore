using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Areas.Admin.Models.ViewModels;

namespace WebStore.Models.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int? CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }

        public Product(ProductViewModel productViewModel)
        {
            Id = productViewModel.Id;
            Name = productViewModel.Name;

            productViewModel.RawPrice.Replace(',', '.');
            Price = double.Parse(productViewModel.RawPrice, System.Globalization.CultureInfo.InvariantCulture);

            Quantity = productViewModel.Quantity;
            CategoryId = productViewModel.CategoryId;
        }

        public Product()
        {

        }
    }
}