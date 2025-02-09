using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen Rehber Adı Giriniz.");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Lütfen Rehber Açıklaması Giriniz.");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Lütfen Rehber Görseli Giriniz.");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen 50 Karakter Sınırını Aşmayınız.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen Minimum 3 Karakter Giriniz.");

        }
    }
}
