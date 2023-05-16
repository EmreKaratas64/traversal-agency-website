using DTOLayer.DTOs.AccountUowDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SendOperationValidator : AbstractValidator<SendOperationModelDto>
    {
        public SendOperationValidator()
        {
            RuleFor(x => x.SenderID).NotEmpty().WithMessage("Sender Id cannot be null!");
            RuleFor(x => x.ReceiverID).NotEmpty().WithMessage("Receiver Id cannot be null!");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount cannot be null!");
            RuleFor(x => x.Amount).LessThan(500000).WithMessage("Amount in one operation cannot exceed 500.000");
        }
    }
}
