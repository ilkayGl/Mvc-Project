﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        IAuthService authService = new AuthManager(
            new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));

        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegister(AdminLogInDto adminLogInDto)
        {
            authService.AdminRegister(adminLogInDto.AdminUserName, adminLogInDto.AdminMail, adminLogInDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }




        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRegister(WriterLogInDto writerLogInDto)
        {
            authService.WriterRegister(
                 writerLogInDto.WriterName,
                 writerLogInDto.WriterSurname,
                 writerLogInDto.WriterAbout,
                 writerLogInDto.Title,
                 //writerLogInDto.WriterImage,
                 writerLogInDto.WriterMail,
                 writerLogInDto.WriterPassword,
                 writerLogInDto.WriterStatus = true
                 );
            //return RedirectToAction("MyContent", "WriterPanelContent");
            return RedirectToAction("MyContent", "WriterPanelContent");
        }
    }
}