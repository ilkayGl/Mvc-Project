using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using System.IO;
using BusinessLayer.ValidationRules;

namespace PresentationLayerUI.Controllers.WriterPanelC
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        MvcKampContext c = new MvcKampContext();
        WriterValidator witerValidator = new WriterValidator();

        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = witerValidator.Validate(p);
            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string _filename = DateTime.Now.ToString("yyymmdd") + fileName;
                    string url = "~/Images/" + _filename;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    p.WriterImage = "/Images/" + _filename;
                }
                p.WriterStatus = true;
                wm.WriterUpdateBL(p);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //ilgili nesnenin adı ve ilgili neseye ait hata mesajını döndür.
                }
            }
            return View();
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var valus = hm.GetListByWriter(writeridinfo);
            return View(valus);

        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList() //dropdown oluşturabilmek için  kategiri listesi için
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());//gelen tarihe bugünün kısa tarih eklenir b
            heading.WriterID = writeridinfo;
            heading.HeadingStatus = true;
            hm.HeadingAddBL(heading);
            return RedirectToAction("MyHeading", "WriterPanel");

        }

        [HttpGet]
        public ActionResult EditWriterHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList() //dropdown oluşturabilmek için  kategiri listesi için
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditWriterHeading(Heading p)
        {
            p.HeadingStatus = true;
            hm.HeadingUpdateBL(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteWriterHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false; //statusu false çevirerek silmeden etkisiz hale getirmiş olur manager kısmındada update işlemi olur.
            hm.HeadingDeleteBL(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int? p = 1) //sayfalama işleminin kaçtan başlayacağına karar verilir.
        {
            var headings = hm.GetList().ToPagedList((int)p, 2);
            return View(headings);
        }
    }
}