using BusinessLayer.Abstract;
using BusinessLayer.Utilities.Cryptos.Hashing;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;


        ////////// Admin ////////

        public AuthManager(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }

        public bool AdminLogIn(AdminLogInDto adminLogInDto)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminLogInDto.AdminMail));
                var admin = _adminService.GetList();
                foreach (var item in admin)
                {
                    if (HashingHelper.AdminVerifyPasswordHash(adminLogInDto.AdminMail, adminLogInDto.AdminPassword, item.AdminMail,
                        item.AdminPasswordHash, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void AdminRegister(string adminUserName, string adminMail, string password)
        {
            byte[] mailHash, passwordHash, passwordSalt;
            HashingHelper.AdminCreatePasswordHash(adminMail, password, out mailHash, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminUserName = adminUserName,
                AdminMail = mailHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                AdminRole = "A"
            };
            _adminService.AdminAddBL(admin);
        }


        //////// Writer ////////

        public bool WriterLogIn(WriterLogInDto writerLogInDto)
        {
            _writerService.GetList();
            return false;
        }

        public void WriterRegister(string writerName, string writerSurname, string writerAbout, string Title, string writerMail, string writerPassword, bool writerStatus)
        {
            //byte[] mailHash, passwordHash, passwordSalt;
            //HashingHelper.WriterCreatePasswordHash(password, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterName = writerName,
                WriterSurname = writerSurname,
                WriterAbout = writerAbout,
                Title = Title,
                //WriterImage = writerImage,
                WriterMail = writerMail,
                WriterPassword = writerPassword,
                WriterStatus = writerStatus
            };
            _writerService.WriterAddBL(writer);
        }
    }
}
