using System;
using System.Web.Mvc;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to URL to show an example";
        }
        public ViewResult AutoProperty()
        {
            //Create a new Product object
            Product myProduct = new Product();
            //set the property value
            myProduct.Name = "Kayak";
            //get the property
            string productName = myProduct.Name;
            //get  the view
            return View("Result", (object)String.Format("Product name: {0}", productName));
        }
        public ViewResult CreateProduct()
        {
            //create a new product object
            Product myProduct = new Product
            {

                //set the propety values
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };
            return View("Result", (object)String.Format("Category: {0}", myProduct.Category));
        }
        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int> { { "apple", 10 }, { "orange", 20 }, { "plum", 30 } };
            return View("Result", (object)stringArray[1]);
        }
        public ViewResult UseExtension()
        {
            //create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart()
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Price = 275M },
                    new Product {Name = "Lifejacket", Price = 48.95M },
                    new Product {Name = "Football ball", Price = 19.50M },
                    new Product {Name = "Corner flag", Price = 34.95M }
                }
            };
            //get the total value of products in the cart'
            decimal cartTotal = cart.TotalPrice();
            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }
        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
            {
                    new Product {Name = "Kayak", Price = 275M },
                    new Product {Name = "Lifejacket", Price = 48.95M },
                    new Product {Name = "Football ball", Price = 19.50M },
                    new Product {Name = "Corner flag", Price = 34.95M }
                }
            };
            decimal cartTotal = products.TotalPrice();
            decimal arrayTotal = products.TotalPrice();
            return View("Result", (object)String.Format("Cart Total: {0:c}, Array Total: {1:c}", cartTotal, arrayTotal));
        }
        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product>
                {
                    new Product {Name = "Kayak", Category ="Watersports", Price = 275M },
                    new Product {Name = "Lifejacket", Category ="Watersports", Price = 48.95M },
                    new Product {Name = "Football ball", Category ="Football", Price = 19.50M },
                    new Product {Name = "Corner flag", Category ="Football", Price = 34.95M }
                }
            };
            Func<Product, bool> categoryFilter = prod => prod.Category == "Football";

            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Football" || prod.Price > 20))
            {
                total += prod.Price;
            }
            return View("Result", (object)String.Format("Total: {0:c}", total));
        }
        /*  public ViewResult CreateAnonArray()
          {
              var oddAndEnds = new[]
              {
                  new {Name = "MVC", Category = "Pattern" },
                  new {Name = "Hat", Category = "Clothing" },
                  new {Name = "Apple", Category = "Fruit" }
              };
              StringBuilder result = new StringBuilder();
              foreach(var item in oddAndEnds)
              {
                  result.Append(item.Name).Append(" ");
              }
              return View("Result",  (object)result.ToString());
          }*/
        public ViewResult FindProducts()
        {
            Product[] products =
            {
                    new Product {Name = "Kayak", Price = 275M },
                    new Product {Name = "Lifejacket", Price = 48.95M },
                    new Product {Name = "Football ball", Price = 19.50M },
                    new Product {Name = "Corner flag", Price = 34.95M }
            };
            var foundProducts = products.OrderByDescending(e => e.Price).Take(3).Select(e => new
            {
                e.Name,
                e.Price
            });
            products[2] = new Product { Name = "Stadium", Price = 79600M };
            //create the result
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0:c} ", p.Price);
            }

            return View("Result", (object)result.ToString());
        }
        public ViewResult SumProducts()
        {
            Product[] products =
            {
                    new Product {Name = "Kayak", Price = 275M },
                    new Product {Name = "Lifejacket", Price = 48.95M },
                    new Product {Name = "Football ball", Price = 19.50M },
                    new Product {Name = "Corner flag", Price = 34.95M }
            };
            var results = products.Sum(e => e.Price);
            products[2] = new Product { Name = "Stadium", Price = 79600M };
            return View("Result", (object)String.Format("Sum: {0:c}", results));
        }
    }
} 