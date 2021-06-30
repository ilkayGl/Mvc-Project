using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        // GET: Content

        public ActionResult Index()
        {
            return View();
        }

        //MvcKampContext c = new MvcKampContext();
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetListContent(p);
          
            //var values = c.Contents.ToList();
            return View(values.ToList());
        }


        public ActionResult ContentByHeading(int id)
        {
            var contentvalue = cm.GetListByHeadingID(id);
            return View(contentvalue);
        }
    }
}