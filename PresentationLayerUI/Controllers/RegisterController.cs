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
    public class RegisterController : Controller
    {
        // GET: Register
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminUserName, loginDto.AdminMail, loginDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}