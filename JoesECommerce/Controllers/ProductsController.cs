﻿using JoesECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoesECommerce.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        // products/index/5 (5 is the value of id in route.
        // use id as page number
        public ActionResult Index(int? id)
        {
            //int page = 1;
            //if (id.HasValue)
            //{
            //    page = id.Value;
            //}

            // ternary operator
            int page = (id.HasValue) ? id.Value : 1;
            const byte PageSize = 2;
            // or this way 
            // int page = id ?? 1;

            // Show the user 1 page worth of products
            List<Product> prods = ProductDB.GetProductsByPage(page, PageSize);

            //Should show user list of all products
            // List<Product> prods = ProductDB.GetAllProducts();
            return View(prods);

            //same as above in 1 statement
            // return View(ProductDB.GetAllProducts());
        }

        /// <summary>
        /// Returns web page to allow creation of products
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            //run validation code
            if (ModelState.IsValid)
            {
                ProductDB.AddProduct(product);
                return RedirectToAction("Index");
            }

            //showing the user the same web page
            //with error messages
            //return view with model and invalid ModelState
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            Product prod = ProductDB.GetProductById(id);
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                ProductDB.Update(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

    }

}