using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.Areas.Admin.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RawPrice { get; set; }
        public int Quantity { get; set; }

        public int? CategoryId { get; set; }

        public ProductViewModel()
        {

        }

        public ProductViewModel(WebStore.Models.Data.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            RawPrice = product.Price.ToString();
            Quantity = product.Quantity;
            CategoryId = product.CategoryId;
        }
    }
}