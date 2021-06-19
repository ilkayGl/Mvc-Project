using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemessiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemessiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Kısmını Boş Geçemessiniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan Kısmını Boş Geçemessiniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifreyi Boş Geçemessiniz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karakterden oluşmalı");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar soyadı en az 2 karakterden oluşmalı");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemessin");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız");
            RuleFor(x => x.Title).MaximumLength(10).WithMessage("Lütfen 10 karakterden fazla değer girişi yapmayınız");
        }
    }
}
