using System;
using System.Web.Mvc;
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
        public ViewResult 
    }
}