using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using PresentationLayerUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PresentationLayerUI.Controllers
{
    public class AdminController : Controller
    {
        AdminManager lm = new AdminManager(new EfAdminDal());
        MvcKampContext c = new MvcKampContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPasswordHash == p.AdminPasswordSalt);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName; //sisteme giren kullanıcın bilgisi gelicek
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //if (!HashingHelper.VerifyPasswordHash(p.AdminPassword))
            //{

            //}

        }
    }
}