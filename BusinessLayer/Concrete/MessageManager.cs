using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListDraft()
        {
            return _messageDal.FilterList(x => x.IsDraft == true);
        }

        public List<Message> GetListImportant()
        {
            return _messageDal.FilterList(x => x.IsImportant == true && x.ReceiverMail == "ilkaygl@outlook.com");
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.FilterList(x => x.ReceiverMail == "ilkaygl@outlook.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.FilterList(x => x.SenderMail == "ilkaygl@outlook.com");
        }

        public List<Message> GetListSpam()
        {
            return _messageDal.FilterList(x => x.IsSpam == true);
        }

        public List<Message> GetListTrash()
        {
            return _messageDal.FilterList(x => x.Trash == true);
        }

        public List<Message> GetReadList()
        {
            return _messageDal.FilterList(x => x.IsRead == true && x.ReceiverMail == "ilkaygl@outlook.com");
        }

        public List<Message> GetUnReadList()
        {
            return _messageDal.FilterList(x => x.ReceiverMail == "ilkaygl@outlook.com" && x.IsRead == false);
        }

        public List<Message> IsDraft()
        {
            return _messageDal.FilterList(x => x.IsDraft == true);
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDeleteBL(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdateBL(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
