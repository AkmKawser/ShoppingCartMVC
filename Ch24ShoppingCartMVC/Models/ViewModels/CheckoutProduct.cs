using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class CheckoutProduct : ProductViewModel
    {
        public decimal TotalPerProduct { get; set; }
        public CheckoutProduct(ProductViewModel product)
        {
            this.ProductID = product.ProductID;
            this.Name = product.Name;
            this.Quantity = product.Quantity;
            this.UnitPrice = product.UnitPrice;
            this.TotalPerProduct = product.UnitPrice * product.Quantity;
        }
    }
}