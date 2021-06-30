﻿using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void AdminRegister(string adminUserName, string adminMail, string password);
        bool AdminLogIn(AdminLogInDto adminLoginDto);
    }
}
