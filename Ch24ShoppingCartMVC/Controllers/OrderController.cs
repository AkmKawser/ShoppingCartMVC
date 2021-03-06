using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers {
    public class OrderController : Controller
    {
        private OrderModel order = new OrderModel();

        [HttpGet]
        public ActionResult Index(string id) {
            //get list for drop down from temp data called products 
            SelectList products = (SelectList)T____________________;
            if (products == null) {
                //CALL THE METHOD GetProductList 
                var list = _________________________________
                //CREATE THE SelectList products
                products = new ________________(list, _________________, "Name", id);
            } 
            //if no URL parameter, get first product from list and refresh
            if (string.IsNullOrEmpty(id)) {
                id = products.ElementAt(0).Value;
                //ASSIGN products to temp data called products
                TempData["products"] = ________________________;
                //Redirect to the action method Index of the Order controller with id parameter.
               _________________________________________________
            }
            else { //get selected product and return in view method
                //Call the method GetOrderInfo to get an OrderViewModel object called model
                _________________________________________________
                //Assign products to ProductsList property of model
               _____________________________
                //Assign the quantity of the SelectProduct of the model to 1
                __________________________________________
                //Send the model object to the view.
                ________________________________
            }
        }
        [HttpPost] //post back - get selected ddl value and refresh
        public RedirectToRouteResult Index(FormCollection collection)
        {
            string pID = collection["ddlProducts"];
            //Redirect to the action method index of the Order controller with parameter the id assigned to pID
            ___________________________________________________
        }      
    }
}
