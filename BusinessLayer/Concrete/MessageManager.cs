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

        public List<Message> GetListDraft(string session)
        {
            return _messageDal.FilterList(x => x.IsDraft == true && x.SenderMail == session);
        }

        public List<Message> GetListImportant(string session)
        {
            return _messageDal.FilterList(x => x.IsImportant == true && x.ReceiverMail == session);
        }

        public List<Message> GetListInbox(string session)
        {
            return _messageDal.FilterList(x => x.ReceiverMail == session);
        }

        public List<Message> GetListSendbox(string session)
        {
            return _messageDal.FilterList(x => x.SenderMail == session);
        }

        public List<Message> GetListSpam(string session)
        {
            return _messageDal.FilterList(x => x.IsSpam == true && x.ReceiverMail==session);
        }

        public List<Message> GetListTrash()
        {
            return _messageDal.FilterList(x => x.Trash == true);
        }

        public List<Message> GetReadList(string session)
        {
            return _messageDal.FilterList(x => x.IsRead == true && x.ReceiverMail == session);
        }

        public List<Message> GetUnReadList(string session)
        {
            return _messageDal.FilterList(x => x.ReceiverMail == session && x.IsRead == false);
        }

        public List<Message> IsDraft(string session)
        {
            return _messageDal.FilterList(x => x.IsDraft == true && x.SenderMail == session);
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
