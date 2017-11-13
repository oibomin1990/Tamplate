using FluentValidation;

namespace MFU.Models.ValidationRules
{
    public class RequestFeeValidator : AbstractValidator<RequestFee>
    {
        public RequestFeeValidator()
        {
            RuleFor(model => model.FeeID).NotEmpty();
            RuleFor(model => model.RequestType).NotEmpty();
            RuleFor(model => model.Amount).NotEmpty();
            RuleFor(model => model.Quantity).NotEmpty();
        }
    }
}
