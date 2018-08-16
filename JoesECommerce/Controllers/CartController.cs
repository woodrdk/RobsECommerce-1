using JoesECommerce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoesECommerce.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Add(int id)
        {
            Product p = ProductDB.GetProductById(id);
            // the user is only adding a single product
            ShoppingCart.AddProduct(p);
            return View(p);
        }

         public ActionResult ViewCart()
        {
            // show user shopping car contents
            throw new NotImplementedException();
        }
    }
}