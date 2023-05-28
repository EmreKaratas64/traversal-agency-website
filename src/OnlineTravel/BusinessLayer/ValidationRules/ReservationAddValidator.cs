using DTOLayer.DTOs.ReservationDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ReservationAddValidator : AbstractValidator<ReservationAddDto>
    {
        public ReservationAddValidator()
        {
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Please enter number of people");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
        }
    }
}
