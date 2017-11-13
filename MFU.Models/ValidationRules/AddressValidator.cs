using FluentValidation;

namespace MFU.Models.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(model => model.ReceiveName).NotEmpty();
            RuleFor(model => model.Address1).NotEmpty();
            RuleFor(model => model.MailingServiceType).NotEmpty();
        }
    }
}
