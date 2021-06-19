using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager IFM = new ImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var ımageList = IFM.GetList();
            return View(ımageList);
        }
    }
}