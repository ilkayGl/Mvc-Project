using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAddBL(Admin admin);
        void AdminDeleteBL(Admin admin);
        void AdminUpdateBL(Admin admin);
        Admin GetByID(int id);
    }
}
