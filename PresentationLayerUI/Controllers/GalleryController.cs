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
    public class GalleryController : Controller
    {
        ImageFileManager IFM = new ImageFileManager(new EfImageFileDal());
        GalleryValidator galleryValidator = new GalleryValidator();
        // GET: Gallery
        public ActionResult Index()
        {
            var ımageList = IFM.GetList();
            return View(ımageList);
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageFile imageFile)
        {
            ValidationResult results = galleryValidator.Validate(imageFile);
            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string _filename = DateTime.Now.ToString("yyyymmdd") + fileName;
                    string url = "~/Images/" + _filename;
                    Request.Files[0].SaveAs(Server.MapPath(url));
                    imageFile.ImagePath = "/Images/" + _filename;
                }
                imageFile.ImageStatus = true;
                IFM.ImageFileAddBL(imageFile);
                return RedirectToAction("Index", "Gallery");
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

        public ActionResult DeleteImage(int id)
        {
            var imageValues = IFM.GetByID(id);
            IFM.ImageFileDeleteBL(imageValues);
            return RedirectToAction("Index","Gallery");
        }


    }
}