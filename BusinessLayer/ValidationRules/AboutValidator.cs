using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen görsel ekleyiniz!");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("En az 50 karakterlik açıklama girilmelidir!");
            RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Açıklamayı kısaltınız!");
        }
    }
}
