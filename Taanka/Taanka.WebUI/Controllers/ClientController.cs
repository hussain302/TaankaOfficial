using Microsoft.AspNetCore.Mvc;
using Taanka.Interfaces;
using Taanka.Mappers;
using Taanka.Models.WebModels;
using Taanka.WebUI.Common;

namespace Taanka.WebUI.Controllers
{
    public class ClientController : Controller
    {
        private readonly IProductRepository services;

        public ClientController(IProductRepository services)
        {
            this.services = services;
        }

        #region Cart, Remove Cart items, Product Details

       
        public IActionResult Cart()
        {
            List<ProductModel> products = HttpContext.Session.Get<List<ProductModel>>("products");
            if (products == null)
            {
                products = new List<ProductModel>();
            }
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            List<ProductModel> products = HttpContext.Session.Get<List<ProductModel>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if(product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction("Cart");                
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
           
            var product = services.GetProduct(id).ToModel();
            if (product == null)
            {
                return NotFound();
            }


            return View(product);
        }

        [Route("ProductDetails")]
        public IActionResult ProductDetails(int id)
        {
            List<ProductModel> products = new List<ProductModel>();
            var product = services.GetProduct(id).ToModel();
            
            if (product == null)
            {
                return NotFound();
            }
            products = HttpContext.Session.Get<List<ProductModel>>("products");
            if(products == null)
            {
                products = new List<ProductModel>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);

            return RedirectToAction("Index");
        }

        #endregion

        #region Show Products

      

        public IActionResult Index()
        {
            try
            {
                var trendingProducts = services.GetProducts()
                    .Where(x=>x.IsTrending == true).Select(x=>x.ToModel());
                return View(trendingProducts);
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Women()
        {
            try
            {
                var products = services.GetProducts()
                    .Where(x=>x.Department == "Women").Select(x=>x.ToModel());
                return View(products);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Formal()
        {
            try
            {
                var products = services.GetProducts()
                    .Where(x=>x.Category == "Formal").Select(x=>x.ToModel());
                return View(products);
            }
            catch
            {
                return View();
            }
        }
        public IActionResult sformal()
        {
            try
            {
                var products = services.GetProducts()
                    .Where(x=>x.Category == "Semi Formal").Select(x=>x.ToModel());
                return View(products);
            }
            catch
            {
                return View();
            }
        }
        
        public IActionResult bridal()
        {
            try
            {
                var products = services.GetProducts()
                    .Where(x=>x.Category == "Bridal").Select(x=>x.ToModel());
                return View(products);
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}
