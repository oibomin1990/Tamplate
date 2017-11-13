using FluentValidation;

namespace MFU.Models.ValidationRules
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(model => model.RequestDetail).SetCollectionValidator(new RequestDetailValidator());
            RuleFor(model => model.AcadYear).NotEmpty();
            RuleFor(model => model.Semester).NotEmpty();
            RuleFor(model => model.GroupDocId).GreaterThan(0);
        }
    }
}
