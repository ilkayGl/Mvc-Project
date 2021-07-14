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
        MvcKampContext c = new MvcKampContext();

        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];

            var messagelistIn = mm.GetListInbox(p);
            return View(messagelistIn);
        }

        public PartialViewResult MessageListMenu_Writer()
        {
            string session = (string)Session["WriterMail"];
            var sendMail = mm.GetListSendbox(session).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInbox(session).Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mm.GetListDraft(session).Count(); //GetListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var trashMail = mm.GetListTrash().Count();
            ViewBag.trashMail = trashMail;

            var readMail = mm.GetReadList(session).Count;
            ViewBag.readMail = readMail;

            var unReadMail = mm.GetUnReadList(session).Count;
            ViewBag.unReadMail = unReadMail;

            var importantMail = mm.GetListImportant(session).Count();
            ViewBag.importantMail = importantMail;

            var spamMail = mm.GetListSpam(session).Count();
            ViewBag.spamMail = spamMail;


           

            return PartialView();
        }


        public PartialViewResult PartialMessageList()
        {
            return PartialView();
        }

        public PartialViewResult PartialMessageListFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialMessageListFooterButton()
        {
            return PartialView();
        }


        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];

            var messageListSend = mm.GetListSendbox(p);
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

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string menuName)
        {
            ValidationResult results = messageValidator.Validate(message);
            string session = (string)Session["WriterMail"];

            //Yeni Mesaj sayfasındaki buton isimlerine göre kontroller aşagıdaki gibi yapılır

            //Eğer kullanıcı Gönder tuşuna basarsa;
            if (menuName == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    //message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBL(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı Taslaklara Kaydet tuşuna basarsa;
            else if (menuName == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = session;
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBL(message);
                    return RedirectToAction("DraftMessages");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            //Eğer kullanıcı İptal tuşuna basarsa;
            else if (menuName == "cancel")
            {
                return RedirectToAction("NewMessage");
            }
            return View();
        }

        public ActionResult DeleteMessage(int id) //Bu alan gelen mesajlarindaki silindi butonundan gelen degeri DB yazar --> Henüz inbox da bu buton eklenmedi !!!
        {
            var result = mm.GetByID(id);
            if (result.Trash == true)
            {
                result.Trash = false;
            }
            else
            {
                result.Trash = true;
            }
            mm.MessageDeleteBL(result);
            return RedirectToAction("Inbox");
        }

        public ActionResult DraftMessages()
        {
            string session = (string)Session["WriterMail"];
            var result = mm.IsDraft(session);
            return View(result);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var result = mm.GetByID(id);
            return View(result);
        }

        public ActionResult IsRead(int id) //Bu alan gelen mesajlarindaki okundu butonundan gelen degeri DB yazar
        {
            var messageValue = mm.GetByID(id);

            if (messageValue.IsRead)
            {
                messageValue.IsRead = false;
            }
            else
            {
                messageValue.IsRead = true;
            }

            mm.MessageUpdateBL(messageValue);
            return RedirectToAction("Inbox");
        }


        public ActionResult IsImportant(int id) //Bu alan gelen mesajlarindaki önemli butonundan gelen degeri DB yazar
        {
            var messageValue = mm.GetByID(id);

            if (messageValue.IsImportant)
            {
                messageValue.IsImportant = false;
            }
            else
            {
                messageValue.IsImportant = true;
            }

            mm.MessageUpdateBL(messageValue);
            return RedirectToAction("Inbox");
        }

    }
}