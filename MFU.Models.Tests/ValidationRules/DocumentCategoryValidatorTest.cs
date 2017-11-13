using MFU.Models.ValidationRules;
using NUnit.Framework;
using FluentValidation.Results;
using MFU.Models.Tests.MockData;
using MFU.Utils;
using System.Collections.Generic;

namespace MFU.Models.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Models.ValidatorRules")]
    public class DocumentCategoryValidatorTest
    {
        private DocumentCategory documentCategory;
        private DocumentCategoryValidator validator;
        private ValidationResult results;

        [SetUp]
        public void SetUp()
        {
            documentCategory = new DocumentCategory();
            validator = new DocumentCategoryValidator();
            results = new ValidationResult();

            documentCategory = MockDocumentCategory.Get();
        }
        [Test]
        public void Should_DocumentCategoryValidator_Name_NotEmpty()
        {
            results = validator.Validate(documentCategory);
            Assert.IsTrue(results.IsValid);

            documentCategory.Name = "";
            results = validator.Validate(documentCategory);
            Assert.IsFalse(results.IsValid);
        }
        [Test]
        public void Should_DocumentCategoryValidator_Name_MaximumLength()
        {
            documentCategory.Name = MockGenerator.GetString(50);
            results = validator.Validate(documentCategory);
            Assert.IsTrue(results.IsValid);

            documentCategory.Name = MockGenerator.GetString(51);
            results = validator.Validate(documentCategory);
            Assert.IsFalse(results.IsValid);
        }
        [Test]
        public void Should_DocumentCategoryValidator_Description_MaximumLength()
        {
            documentCategory.Description = MockGenerator.GetString(255);
            results = validator.Validate(documentCategory);
            Assert.IsTrue(results.IsValid);

            documentCategory.Description = MockGenerator.GetString(256);
            results = validator.Validate(documentCategory);
            Assert.IsFalse(results.IsValid);
        }
        [Test]
        public void Should_DocumentCategoryValidator_Name_IsNameUnique()
        {
            var documents = new List<DocumentCategory>();
            documents.Add(documentCategory);
            validator = new DocumentCategoryValidator(documents);

            results = validator.Validate(documentCategory);
            Assert.IsFalse(results.IsValid);
      
            results = validator.Validate(new DocumentCategory() { Id = 999 , Name = "TEST" });
            Assert.IsTrue(results.IsValid);
        }
    }
}