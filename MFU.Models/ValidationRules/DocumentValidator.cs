using FluentValidation;

namespace MFU.Models.ValidationRules
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            RuleFor(documentCategory => documentCategory.Id).NotEmpty();
            RuleFor(documentCategory => documentCategory.CreatedDate).NotEmpty();
            RuleFor(documentCategory => documentCategory.ModifiedDate).NotEmpty();

            RuleFor(documentCategory => documentCategory.Name).NotEmpty().MaximumLength(50);
            RuleFor(documentCategory => documentCategory.Description).MaximumLength(255);
        }
    }
}
