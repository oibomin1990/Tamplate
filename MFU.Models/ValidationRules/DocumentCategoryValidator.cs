using System.Linq;
using FluentValidation;
using System.Collections.Generic;

namespace MFU.Models.ValidationRules
{
    public class DocumentCategoryValidator : AbstractValidator<DocumentCategory>
    {
        private readonly IEnumerable<DocumentCategory> _documentCategorys;
        public DocumentCategoryValidator()
        {
            Validation();
        }

        public DocumentCategoryValidator(IEnumerable<DocumentCategory> documentCategorys)
        {
            _documentCategorys = documentCategorys;
            Validation();
            RuleFor(model => model.Name).Must(IsNameUnique).WithMessage("Name must be unique");
        }

        private void Validation()
        {
            RuleFor(documentCategory => documentCategory.Id).NotEmpty();
            RuleFor(documentCategory => documentCategory.CreatedDate).NotEmpty();
            RuleFor(documentCategory => documentCategory.ModifiedDate).NotEmpty();

            RuleFor(documentCategory => documentCategory.Name).NotEmpty().MaximumLength(50);
            RuleFor(documentCategory => documentCategory.Description).MaximumLength(255);
            RuleFor(model => model.Documents).SetCollectionValidator(new DocumentValidator());
        }

        public bool IsNameUnique(DocumentCategory editedDocumentCategory, string newValue)
        {
            return _documentCategorys.All(documentCategory => documentCategory.Name != newValue);
        }
    }
}
