using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PresentationLayerUI.Controllers
{

    [AllowAnonymous] //Proje bazinda olusturulan kurallardan muaf tutuyor. Sadece bulundugu sayfa.
    public class LoginController : Controller
    {

        // GET: Login
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());



        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogIn(AdminLogInDto adminLogInDto)
        {
            //var response = Request["g-recaptcha-response"];
            //const string secret = "6Lc9zzgbAAAAAFBGD3Gb201yvNAX4Tb5LAzlqy0d";
            //var client = new WebClient();
            //var reply =
            //    client.DownloadString(
            //        string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            //var captchaResponse = JsonConvert.DeserializeObject<CaptchaResult>(reply);

            if (authService.AdminLogIn(adminLogInDto))
            {
                FormsAuthentication.SetAuthCookie(adminLogInDto.AdminMail, false);
                Session["AdminMail"] = adminLogInDto.AdminMail;
                var session = Session["AdminMail"];
                ViewBag.a = session;
                return RedirectToAction("Index", "Heading");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return RedirectToAction("AdminLogin");
            }

        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "LogIn");
        }

        [HttpGet]
        public ActionResult WriterLogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogIn(Writer p)
        {
            MvcKampContext c = new MvcKampContext();
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            wm.GetWriter(p.WriterMail, p.WriterPassword);

            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View("WriterLogin");
            }

        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin", "Login");
        }


    }
}