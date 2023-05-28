using DTOLayer.DTOs.ReservationDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ReservationUpdateValidator : AbstractValidator<ReservationUpdateDto>
    {
        public ReservationUpdateValidator()
        {
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Please enter number of people");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
        }

    }
}
