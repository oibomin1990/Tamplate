using MFU.Models.ValidationRules;
using NUnit.Framework;
using FluentValidation.Results;
using MFU.Models.Tests.MockData;
using MFU.Utils;

namespace MFU.Models.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Models.ValidatorRules")]
    public class DocumentValidatorTest
    {
        private Document document;
        private DocumentValidator validator;
        private ValidationResult results;

        [SetUp]
        public void SetUp()
        {
            document = new Document();
            validator = new DocumentValidator();
            results = new ValidationResult();

            document = MockDocument.Get();
        }
        [Test]
        public void Should_DocumentValidator_Name_NotEmpty()
        {
            results = validator.Validate(document);
            Assert.IsTrue(results.IsValid);

            document.Name = "";
            results = validator.Validate(document);
            Assert.IsFalse(results.IsValid);
        }
        [Test]
        public void Should_DocumentValidator_Name_MaximumLength()
        {
            document.Name = MockGenerator.GetString(50);
            results = validator.Validate(document);
            Assert.IsTrue(results.IsValid);

            document.Name = MockGenerator.GetString(51);
            results = validator.Validate(document);
            Assert.IsFalse(results.IsValid);
        }
        [Test]
        public void Should_DocumentValidator_Description_MaximumLength()
        {
            document.Description = MockGenerator.GetString(255);
            results = validator.Validate(document);
            Assert.IsTrue(results.IsValid);

            document.Description = MockGenerator.GetString(256);
            results = validator.Validate(document);
            Assert.IsFalse(results.IsValid);
        }
    }
}