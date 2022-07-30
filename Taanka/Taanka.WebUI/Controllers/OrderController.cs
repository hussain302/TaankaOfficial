using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taanka.DataAccess;
using Taanka.Mappers;
using Taanka.Models.DomainModels;
using Taanka.Models.WebModels;
using Taanka.WebUI.Common;

namespace Taanka.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly TaankaContext db;

        public OrderController(TaankaContext db)
        {
            this.db = db;
        }

        #region Order Management
        public IActionResult Manage()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            try
            {
                if (ViewBag.Name != null && ViewBag.Role != null)
                {
                    var allOrders = db.Orders.ToList();
                    return View(allOrders.Select(x => x.ToModel()));
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            catch
            {
                return RedirectToAction("Manage");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var find = db.Orders.Find(id);
            db.Orders.Remove(find);
            db.SaveChanges();
            return RedirectToAction("Manage");

        }
         [HttpGet]
        public IActionResult Approve(int id)
        {
            var find = db.Orders.Find(id);
            find.IsApproved = true;
            db.Orders.Update(find);
            db.SaveChanges();
            return RedirectToAction("Manage");

        }
        #endregion

        #region Checkout Logic
        [HttpGet]
        public IActionResult CheckOut()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CheckOut(OrderModel Model)
        {
            List<ProductModel> products = HttpContext.Session.Get<List<ProductModel>>("products");

            Model.OrderNo = GetOrderNo();
            Model.OrderDate = DateTime.Now;
            Model.TotalAmount = products.Sum(x => x.Price);
            Model.Details = String.Join(", ", products.Select(x => x.Title));
            Model.IsApproved = false;
            db.Orders.Add(Model.ToDB());
            db.SaveChanges();

            products = new List<ProductModel>();
            
            HttpContext.Session.Set("products",products);

            return RedirectToAction("Index", "Client");
        }

        public string GetOrderNo()
        {
            int rowCount = db.Orders.ToList().Count + 1;
            return rowCount.ToString("000");
        }
        #endregion

    }
}
