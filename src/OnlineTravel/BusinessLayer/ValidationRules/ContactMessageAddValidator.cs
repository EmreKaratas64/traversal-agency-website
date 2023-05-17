using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactMessageAddValidator : AbstractValidator<ContactMessageAddDto>
    {
        public ContactMessageAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please type your name");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must exceed 2 characters");
            RuleFor(x => x.Name).MaximumLength(60).WithMessage("Name cannot exceed 60 characters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please type message content");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Message content must exceed 10 characters");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Message content cannot exceed 500 characters");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Please type your mail");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Please type a valid mail");
        }
    }
}
