using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<AnnouncementAddDTOs>
    {
        public AnnouncementValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Lütfen Başlığı Boş Geçmeyiniz");
            RuleFor(x=>x.Content).NotEmpty().WithMessage("Lütfen İçeriği Boş Geçmeyiniz");

            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Başlık Veri Girişi Yapınız");
            RuleFor(x => x.Content).MinimumLength(10).WithMessage("Lütfen En Az 10 Karakter İçerik Veri Girişi Yapınız");

            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Başlık Veri Girişi Yapınız");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen En Fazla 500 Karakter İçerik Veri Girişi Yapınız");
        }
    }
}
