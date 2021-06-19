using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        // MvcKampContext c = new MvcKampContext();
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult MessageListMenu()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetListSendbox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mm.GetListDraft().Count(); //GetListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var trashMail = mm.GetListTrash().Count();
            ViewBag.trashMail = trashMail;

            var readMail = mm.GetReadList().Count;
            ViewBag.readMail = readMail;

            var unReadMail = mm.GetUnReadList().Count;
            ViewBag.unReadMail = unReadMail;

            var importantMail = mm.GetListImportant().Count();
            ViewBag.importantMail = importantMail;

            var spamMail = mm.GetListSpam().Count();
            ViewBag.spamMail = spamMail;


            return PartialView();
        }

        public ActionResult IsRead(int id) //Bu alan sistem mesajlarindaki okundu butonundan gelen degeri DB yazar
        {
            var contactValue = cm.GetByID(id);

            if (contactValue.IsRead)
            {
                contactValue.IsRead = false;
            }
            else
            {
                contactValue.IsRead = true;
            }

            cm.ContactUpdateBL(contactValue);
            return RedirectToAction("Index");
        }


        public ActionResult IsImportant(int id) //Bu alan sistem mesajlarindaki önemli butonundan gelen degeri DB yazar
        {
            var contactValue = cm.GetByID(id);

            if (contactValue.IsImportant)
            {
                contactValue.IsImportant = false;
            }
            else
            {
                contactValue.IsImportant = true;
            }

            cm.ContactUpdateBL(contactValue);
            return RedirectToAction("Index");
        }
    }
}