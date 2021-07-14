using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    
    public class HomeController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MvcKampContext _context = new MvcKampContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult HomePage()
        {       
            var totalCategory = _context.Categories.Count(); //Toplam Kategori Sayisi
            ViewBag.totalNumberOfCategories = totalCategory;

            var totalHeading = _context.Headings.Count(); //Toplam Baslik sayisi
            ViewBag.totalHeading = totalHeading;

            var totalWriter = _context.Writers.Count();//Toplam Yazar sayisi
            ViewBag.totalWriter = totalWriter;

            var categoryStatusTrue = _context.Categories.Count(x => x.CategoryStatus == true); // Kategoriler tablosundaki aktif kategori sayisi
            ViewBag.activeCategories = categoryStatusTrue;

            var totalContacts = _context.Contacts.Count();
            ViewBag.totalContacts = totalContacts;

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult HomePage(Contact p)
        {
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContactAddBL(p);
            return RedirectToAction("HomePage", "Home");
        }
    }
}