﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers.WriterPanelC
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            var valus = hm.GetListByWriter();
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
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToLongTimeString());//gelen tarihe bugünün kısa tarih eklenir b
            heading.WriterID = 4;
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
    }
}