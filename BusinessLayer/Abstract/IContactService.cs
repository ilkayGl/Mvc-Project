using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        Contact GetByIdContactAndSetRead(int id, bool read);
        void ContactAddBL(Contact contact);
        void ContactDeleteBL(Contact contact);
        void ContactUpdateBL(Contact contact);
        Contact GetByID(int id);
    }
}
