using FluentValidation.Results;
using MFU.Models.ValidationRules;
using NUnit.Framework;

namespace MFU.Models.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Models.ValidatorRules")]
    class RequestValidatorTest
    {
        private Request request;
        private RequestValidator validator;
        private ValidationResult results;

        [SetUp]
        public void SetUp()
        {
            request = new Request();
            validator = new RequestValidator();
            results = new ValidationResult();
        }

        [Test]
        public void Should_RequestValidator_NotEmpty_Field()
        {
            var result = validator.Validate(request);
            Assert.IsFalse(result.IsValid);

            request.AcadYear = 2560;
            request.Semester = 2;
            request.GroupDocId = 1;
            result = validator.Validate(request);
            Assert.IsTrue(result.IsValid);
        }
    }
}

