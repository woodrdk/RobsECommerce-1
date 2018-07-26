using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoesECommerce.Models
{
    public static class ProductDB
    {
        /// <summary>
        /// Gets all products sorted by product name
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProducts()
        {
            //LINQ (Language Integrated Query)

            var db = new CommerceDbContext();

            //What we are trying to do
            //SELECT * FROM Products ORDER BY Name

            //Method 1: LINQ Query Syntax
            List<Product> products =
                (from p in db.Products
                orderby p.Name
                select p).ToList();

            //Method 2: LINQ Method Syntax
            List<Product> products2 =
                db.Products
                    .OrderBy(p => p.Name)
                    .ToList();

            return products;
        }

        internal static List<Product> GetProductsByPage(int page, byte pageSize)
        {
            CommerceDbContext context = new CommerceDbContext();
            List<Product> prodList =
                context
                .Products
                .Take(pageSize)
                .OrderBy( p => p.Name)
                .Skip(( page - 1 )* pageSize)
                .ToList();
            return prodList;
        }

        /// <summary>
        /// Add product to the database
        /// </summary>
        /// <param name="p">Product to be added</param>
        public static void AddProduct(Product p)
        {
            //Create instance of DBContext class
            var context = new CommerceDbContext();

            //Prepare insert statement
            context.Products.Add(p);

            //Execute pending insert
            context.SaveChanges();
        }

        internal static Product GetProductById(int id)
        {
            CommerceDbContext context = new CommerceDbContext();
            Product p = context.Products.Find(id);
            return p;
        }

        public static void Update(Product p)
        {
            var context = new CommerceDbContext();
            // tells EF this product has only been modified
            context.Entry(p).State = System.Data.Entity.EntityState.Modified;
            // send update querty to the database
            context.SaveChanges();
        }
    }
}