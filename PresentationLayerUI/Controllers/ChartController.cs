using DataAccessLayer.Concrete.EntityFramework;
using PresentationLayerUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    public class ChartController : Controller
    {
        //GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryPieChart()
        {
            return View();
        }

        public ActionResult WriterColumnChart()
        {
            return View();
        }

        public ActionResult TalentLineChart()
        {
            return View();
        }

        public List<CategoryChart> CategoryList()
        {
            List<CategoryChart> categoryCharts = new List<CategoryChart>();
            using (var MvcKampContext = new MvcKampContext())
            {
                categoryCharts = MvcKampContext.Categories.Select(c => new CategoryChart
                {
                    CategoryName = c.CategoryName,
                    CategoryCount = c.Headings.Count()
                }).ToList();
            }

            return categoryCharts;
        }

        public ActionResult CategoryCharts()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterChart> WriterList()
        {
            List<WriterChart> writerCharts = new List<WriterChart>();
            using (var MvcKampContext = new MvcKampContext())
            {
                writerCharts = MvcKampContext.Writers.Select(c => new WriterChart
                {
                    WriterName = c.WriterName,
                    WriterCount = c.Headings.Count()
                }).ToList();
            }

            return writerCharts;
        }

        public ActionResult WriterChart()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }

        //public List<TalentChart> TalentList()
        //{
        //    List<TalentChart> talentCharts = new List<TalentChart>();
        //    using (var MvcKampContext = new MvcKampContext())
        //    {
        //        talentCharts = MvcKampContext.Talents.Select(c => new TalentChart
        //        {
        //            TalentName = c.TalentName,
        //            TalentRange = c.Range
        //        }).ToList();
        //    }

        //    return talentCharts;
        //}

        //public ActionResult TalentChart()
        //{
        //    return Json(TalentList(), JsonRequestBehavior.AllowGet);
        //}

    }
}