using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        //MvcKampContext mvcKamp = new MvcKampContext();
        WriterValidator witerValidator = new WriterValidator();


        // GET: Writer
        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult results = witerValidator.Validate(writer);
            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string _filename = DateTime.Now.ToString("yyyymmdd") + fileName;
                    string url = "~/Images/" + _filename;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    writer.WriterImage = "/Images/" + _filename;
                }
                writer.WriterStatus = true;
                wm.WriterAddBL(writer);
                return RedirectToAction("Index");
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


        [HttpGet]
        public ActionResult EditWrite(int id)
        {
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWrite(Writer p)
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
                return RedirectToAction("Index");
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


    }
}








//[HttpGet]
//public ActionResult AddImage()
//{
//    return View();
//}

//[HttpPost]
//public ActionResult AddImage(Writer writer)
//{
//    if (Request.Files.Count > 0)
//    {
//        string fileName = Path.GetFileName(Request.Files[0].FileName);
//        string extension = Path.GetExtension(Request.Files[0].FileName);
//        string url = "~/Images/" + fileName + extension;
//        Request.Files[0].SaveAs(Server.MapPath(url));
//        writer.WriterImage = "/Images/" + fileName + extension;
//    }
//    mvcKamp.Writers.Add(writer);
//    mvcKamp.SaveChanges();
//    return RedirectToAction("Index");
//}