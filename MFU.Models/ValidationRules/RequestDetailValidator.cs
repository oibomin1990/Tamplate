using FluentValidation;

namespace MFU.Models.ValidationRules
{
    public class RequestDetailValidator : AbstractValidator<RequestDetail>
    {
        public RequestDetailValidator()
        {
            RuleFor(model => model.Quantity).GreaterThan(0);
            RuleFor(model => model.RequestType.RequestTypeID).NotEmpty();
        }
    }
}
