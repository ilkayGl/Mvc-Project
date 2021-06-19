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
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = am.GetList();
            return View(aboutvalues); //popup verilerin listelendiği sayfada kullanılır
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.AboutAddBL(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView(); // sağ tıklayıp PartialView kutusunu işaretleyerek  oluştururuz viewi
        }

        public ActionResult IsActive(int id)
        {
            var aboutValue = am.GetByID(id);
            if (aboutValue.Status)
            {
                aboutValue.Status = false;
            }
            else
            {
                aboutValue.Status = true;
            }
            am.AboutUpdateBL(aboutValue);
            return RedirectToAction("Index");
        }
    }
}