using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bu alan Boş Geçilemez");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("En fazla 20 karakter girilebilir");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("En az 2 karakter girilmelidir");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En fazla 50 karakter girilebilir");
        }
    }
}
