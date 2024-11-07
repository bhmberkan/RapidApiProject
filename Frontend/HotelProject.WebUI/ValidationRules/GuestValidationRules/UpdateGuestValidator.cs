using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı boş geçilemez");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("City Alanı Boş Geçilemez");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim Alanı için En az 3 karakterlik veri girişi yapınız.");
            RuleFor(x => x.SurName).MinimumLength(4).WithMessage("Soyisim Alanı için En az 4 karakterlik veri girişi yapınız.");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Şehir Alanı için En az 3 karakterlik veri girişi yapınız.");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim Alanı için En Fazla 20 karakterlik veri girişi yapınız.");
            RuleFor(x => x.SurName).MaximumLength(30).WithMessage("Soyisim Alanı için En Fazla 30 karakterlik veri girişi yapınız.");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Şehir Alanı için En Fazla 20 karakterlik veri girişi yapınız.");

        }

    }
}
