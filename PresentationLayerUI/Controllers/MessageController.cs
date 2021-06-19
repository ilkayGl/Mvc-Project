using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();


        // GET: Message
        public ActionResult Inbox()
        {
            var messagelistIn = mm.GetListInbox();

            return View(messagelistIn);
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

        [HttpPost, ValidateInput(false)]
        public ActionResult NewMessage(Message message, string menuName)
        {
            ValidationResult results = messageValidator.Validate(message);

            //Eğer kullanıcı Gönder tuşuna basarsa;
            if (menuName == "send")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "ilkaygl@outlook.com";
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString()); //şuanın tarihini al
                    mm.MessageAddBL(message);
                    return RedirectToAction("SendBox", "WriterPanelMessage");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //ilgili nesnenin adı ve ilgili neseye ait hata mesajını döndür.
                    }
                }
            }
            //Eğer kullanıcı Taslaklara Kaydet tuşuna basarsa;
            else if (menuName == "draft")
            {
                if (results.IsValid)
                {
                    message.SenderMail = "ilkaygl@outlook.com";
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
            var result = mm.IsDraft();
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