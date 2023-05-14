using DTOLayer.DTOs.VisitorDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class VisitorUpdateValidator : AbstractValidator<VisitorModelDto>
    {
        public VisitorUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please type a name");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Please type a surname");
            RuleFor(x => x.City).NotEmpty().WithMessage("Please type a city");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Please type a country");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Please type a mail");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Please enter a valid mail address");
        }
    }
}
