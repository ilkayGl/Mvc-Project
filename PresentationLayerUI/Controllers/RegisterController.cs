using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));

        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegister(AdminLogInDto adminLogInDto)
        {
            authService.AdminRegister(adminLogInDto.AdminUserName, adminLogInDto.AdminMail, adminLogInDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}