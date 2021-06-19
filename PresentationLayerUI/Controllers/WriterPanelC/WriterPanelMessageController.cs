using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PresentationLayerUI.Controllers.WriterPanelC
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            var messagelistIn = mm.GetListInbox();

            return View(messagelistIn);
        }

        public PartialViewResult MessageListMenu_Writer()
        {
            return PartialView();
        }

        public ActionResult SendBox()
        {
            var messageListSend = mm.GetListSendbox();
            return View(messageListSend);
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = "gzm@gmail.com";
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //şuanın tarihini al
                mm.MessageAddBL(p);
                return RedirectToAction("SendBox");
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