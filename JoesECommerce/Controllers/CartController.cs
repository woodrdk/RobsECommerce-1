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
            // add product to cart
            Product p = ProductDB.GetProductById(id);

            string cartData = JsonConvert.SerializeObject(p);
            HttpCookie cookie = new HttpCookie("Cart");
            cookie.Value = cartData;
            cookie.Expires = DateTime.Now.AddYears(5);
            Response.Cookies.Add(cookie);
            return View(p);
        }

         public ActionResult ViewCart()
        {
            // shor user shopping car contents
            throw new NotImplementedException();
        }
    }
}