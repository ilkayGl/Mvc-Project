using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        List<Message> GetReadList();
        List<Message> GetUnReadList();
        List<Message> IsDraft();
        List<Message> GetListDraft();
        List<Message> GetListTrash();
        List<Message> GetListSpam();
        List<Message> GetListImportant();
        void MessageAddBL(Message message);
        void MessageDeleteBL(Message message);
        void MessageUpdateBL(Message message);
        Message GetByID(int id);
    }
}
