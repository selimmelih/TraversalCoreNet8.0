using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(x=>x.Username).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Parola Alanı Boş Geçilemez");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Parola Tekrar Alanı Boş Geçilemez");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Lütfen kullanıcı adını en az 5 karakter veri girişi yapınız.");
            RuleFor(x => x.Username).MaximumLength(50).WithMessage("Lütfen kullanıcı adını en az 50 karakter veri girişi yapınız.");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Parolalar birbiriyle uyuşmuyor.");
        }
    }
}
