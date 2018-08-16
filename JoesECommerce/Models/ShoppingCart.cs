using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoesECommerce.Models
{
    public static class ShoppingCart
    {
        /// <summary>
        /// This method returns the total number of items 
        /// Includes duplicate products. Aka if 5 of one item and 2 more items will still be 7 items
        /// </summary>
        /// <returns></returns>
        public static short GetTotalItems()
        {
            List<Product> products = GetProducts();
            short numProducts = 0;

            foreach (Product p in products)
            {
                numProducts += p.Quantity;
            }
            return numProducts;
        }

        public static List<Product> GetProducts()
        {
            List<Product> prods = new List<Product>();
            HttpCookie cartCookie = HttpContext.Current.Request.Cookies["Cart"];
            if(cartCookie == null)
            {
                return prods;
            }
            prods = JsonConvert.DeserializeObject<List<Product>>(cartCookie.Value);
            return prods;
        }

        public static void AddProduct(Product p)
        {
            List<Product> products = new List<Product>();
            products.Add(p);

            string jsonData = JsonConvert.SerializeObject(products);
            HttpCookie cookie = new HttpCookie("Cart");
            cookie.Value = jsonData;
            cookie.Expires = DateTime.Now.AddYears(5);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}