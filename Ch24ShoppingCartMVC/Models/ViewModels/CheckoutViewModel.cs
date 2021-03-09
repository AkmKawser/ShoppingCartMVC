using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public List<CheckoutProduct> ProductList { set; get; }
        public decimal Total { get; set; }
        public decimal TotalWithTax { get; set; }
        public List<SelectListItem> PaymentOptions = new List<SelectListItem>()
        {
            new SelectListItem(){Text ="Visa",Value="visa"},
            new SelectListItem(){Text ="Mastercard",Value="mastercard"},
            new SelectListItem(){Text ="Paypal",Value="paypal"}
        };


        public CheckoutViewModel(List<ProductViewModel> products)
        {
            ProductList = new List<CheckoutProduct>();
            foreach (ProductViewModel product in products)
            {
                CheckoutProduct checkoutProduct = new CheckoutProduct(product);
                ProductList.Add(checkoutProduct);
                this.Total += checkoutProduct.TotalPerProduct;
            }
            this.TotalWithTax = Total + Total * (decimal)0.15;
        }
    }
}