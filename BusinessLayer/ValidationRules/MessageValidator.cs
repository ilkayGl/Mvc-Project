using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemessiniz");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcıyı boş geçemessiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemessiniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Girilen metin geçerli bir e-posta adresi değil");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakteri aşmayınız");
        }
    }
}
