using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private Product[] products =
        {
              new Product {Name = "Kayak", Category ="Watersports", Price = 275M },
              new Product {Name = "Lifejacket", Category ="Watersports", Price = 48.95M },
              new Product {Name = "Football ball", Category ="Football", Price = 19.50M },
              new Product {Name = "Corner flag", Category ="Football", Price = 34.95M }
        };
        public ActionResult Index()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            ShoppingCart cart = new ShoppingCart(calc)
            {
                Products = products
            };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}