using Ch24ShoppingCartMVC.Models;
using Ch24ShoppingCartMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckoutController : Controller
    {
        CartModel cart = new CartModel();
        //
        // GET: /Checkout/

        public ActionResult Index()
        {
            CartViewModel model = cart.GetCart();

            CheckoutViewModel checkoutViewModel = new CheckoutViewModel(model.Cart);

            return View(checkoutViewModel);
        }
        [HttpPost]
        public ActionResult Pay()
        {
            Session["cart"] = null;

            return RedirectToAction("Index", "Home");
        }

    }
}
