using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers.WriterPanelC
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        MvcKampContext c = new MvcKampContext();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentvalue = cm.GetListByWriter(writeridinfo);

            return View(contentvalue);
            //sisteme kiminle otantike olursam onun bilgilerini bana vericektir
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id; //id den gelen değeri addcontente taşıyoruz
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;

            p.ContentStatus = true;

            cm.ContentAddBL(p);
            return RedirectToAction("MyContent");
        }

       
    }
}