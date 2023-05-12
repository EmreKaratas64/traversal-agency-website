using DTOLayer.DTOs.NotificationDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class NotificationAddValidator : AbstractValidator<NotificationAddDto>
    {
        public NotificationAddValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Please type the subject");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please type the description");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Subject must be at least 5 characters");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Description must be at least 5 characters");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Subject cannot exceed 50 characters");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
        }
    }
}
