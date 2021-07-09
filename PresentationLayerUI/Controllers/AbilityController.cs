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
    public class AbilityController : Controller
    {
        AbilityManager am = new AbilityManager(new EfAbilityDal());

        // GET: Ability
        public ActionResult Index()
        {
            var abilityvalues = am.GetList();
            return View(abilityvalues);
        }

        public ActionResult AbilityList()
        {
            var abilityvalues = am.GetList();
            return View(abilityvalues);
        }

        [HttpGet]
        public ActionResult AbilityAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AbilityAdd(Ability p)
        {
            am.AbilityAddBL(p);
            return RedirectToAction("Index");
        }

        public ActionResult AbilityDelete(Ability p)
        {
            am.AbilityDeleteBL(p);
            return RedirectToAction("Index");
        }
    }
}