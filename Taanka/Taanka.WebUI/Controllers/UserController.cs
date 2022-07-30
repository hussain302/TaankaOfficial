using Microsoft.AspNetCore.Mvc;
using Store.AdminWebUI.Common;
using Taanka.Interfaces;
using Taanka.Mappers;
using Taanka.Models.WebModels;

namespace Taanka.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository services;

        public UserController(IUserRepository services)
        {
            this.services = services;
        }

        #region User Management

        public IActionResult Manage()
        {
            try
            {
                ViewBag.Name = HttpContext.Session.GetString("Name");
                ViewBag.Role = HttpContext.Session.GetString("Role");
                if (ViewBag.Name != null && ViewBag.Role != null)
                {
                    if (ViewBag.Role == WebUtils.SUPER_ADMIN_ROLE_NAME)
                    {
                        var userList = services.GetUsers().Select(x => x.ToModel());
                        return View(userList);
                    }
                    else
                    {
                        ViewBag.message = "You Aren't Authorized";
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Login", "User");
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Approved(int id)
        {
            var model =  services.GetUser(id);
            services.ApproveUser(model);
            return RedirectToAction("Manage");
        }

        public IActionResult Delete(int id)
        {
            var model =  services.GetUser(id);
            services.RemoveUser(model.Id);
            return RedirectToAction("Manage");
        }

        #endregion


        #region Login SignUp

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel model)
        {
            var checkUser = services.GetUser(loginid: model.LoginId, password: model.Password);
            if (checkUser != null && checkUser.IsActive != false)
            {
                if (checkUser.Role.Name == WebUtils.SUPER_ADMIN_ROLE_NAME || checkUser.Role.Name == WebUtils.ADMIN_ROLE_NAME)
                {
                    HttpContext.Session.SetString("Name", checkUser.Name);
                    HttpContext.Session.SetString("Role", checkUser.Role.Name);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (checkUser.Role.Name == "pending") ViewBag.Message = "User Is Not Approved Yet!";
                    else ViewBag.Message = "Enter Valid Credentials!";
                    return View();
                }
            }
            else
            {
                try { if (checkUser.IsActive != true) ViewBag.Message = "User Is Not Approved Yet!"; }
                catch { if (checkUser == null) ViewBag.Message = "Enter Valid Credentials!"; }
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            var find = services.GetUser(model.LoginId);

            if (find == null)
            {
                services.AddUser(model: model.ToDB());
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = "User already exist try different Username";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        #endregion

    }
}
