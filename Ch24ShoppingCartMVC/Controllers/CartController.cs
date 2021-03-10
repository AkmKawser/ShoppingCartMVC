using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers {
    public class CartController : Controller
    {
        private CartModel cart = new CartModel();

        [HttpGet]
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("List/");
        }
        [HttpGet]
        public ViewResult List()
        {
            CartViewModel model = (CartViewModel)TempData["cart"];
            //if the model is null, then call the method GetCart
            model = model ?? cart.GetCart();
            //Passing model to View
            return View(model);
        }
        [HttpPost]
        public RedirectToRouteResult List(OrderViewModel order)
        {
            if (order.SelectedProduct.Quantity<1)
            {

                TempData["invQ"] = order.SelectedProduct.Quantity;
                return RedirectToAction("Index", "Order", new { id = order.SelectedProduct.ProductID });
            }
            
            
            CartViewModel model = cart.GetCart(order.SelectedProduct.ProductID);
            //Assign the quantity of the selected product to the quantity of the added product
            model.AddedProduct.Quantity = order.SelectedProduct.Quantity;
            //Call the method AddtoCart
            cart.AddToCart(model);
            //Assign model to the TempData
            TempData["cart"] = model;  //data passign from controller to view
            return RedirectToAction("List", "Cart");
        }
       
    }
}
