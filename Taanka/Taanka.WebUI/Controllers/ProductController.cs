using Microsoft.AspNetCore.Mvc;
using Taanka.Interfaces;
using Taanka.Mappers;
using Taanka.Models.WebModels;

namespace Taanka.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository services;
        private readonly IWebHostEnvironment web;
        public ProductController(IProductRepository services, IWebHostEnvironment web)
        {
            this.services = services;
            this.web = web;
        }




        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Name != null && ViewBag.Role != null)
            {
                var products = services.GetProducts().Select(x => x.ToModel());
                return View(products);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Name != null && ViewBag.Role != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            try
            {
                if (model.PhotoFile != null)
                {
                    string folder = "Images/Products/";
                    folder += model.PhotoFile.FileName;

                    model.Image_url_path = "/" + folder;
                    string serverfolder = Path.Combine(web.WebRootPath, folder);
                    model.PhotoFile.CopyTo(new FileStream(serverfolder, FileMode.Create));
                }
                if(model.IsTrending == null)
                {
                    model.IsTrending = false;
                }
                services.AddProduct(model.ToDB());
                return RedirectToAction("Manage");
            }
            catch
            {
                return RedirectToAction("Manage");
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Name != null && ViewBag.Role != null)
            {
                return View(services.GetProduct(id).ToModel());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            try
            {
                if (model.PhotoFile != null)
                {
                    string folder = "Images/Products/";
                    folder += model.PhotoFile.FileName;

                    model.Image_url_path = "/" + folder;
                    string serverfolder = Path.Combine(web.WebRootPath, folder);
                    model.PhotoFile.CopyTo(new FileStream(serverfolder, FileMode.Create));
                }
                if(model.IsTrending == null)
                {
                    model.IsTrending = false;
                }
                services.UpdateProduct(model.ToDB());
                return RedirectToAction("Manage");
            }
            catch
            {
                return RedirectToAction("Manage");
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Name != null && ViewBag.Role != null)
            {
                return View(services.GetProduct(id).ToModel());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        [HttpPost]
        public IActionResult Delete(ProductModel model)
        {
            try
            {
                services.RemoveProduct(model.Id);
                return RedirectToAction("Manage");
            }
            catch
            {
                return RedirectToAction("Manage");
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if (ViewBag.Name != null && ViewBag.Role != null)
            {
                return View(services.GetProduct(id).ToModel());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}
