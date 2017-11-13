using FluentValidation.Results;
using MFU.Models.ValidationRules;
using NUnit.Framework;

namespace MFU.Models.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Models.ValidatorRules")]
    class RequestDetailValidatorTest
    {
        private RequestDetail requestDetail;
        private RequestDetailValidator validator;
        private ValidationResult results;

        [SetUp]
        public void SetUp()
        {
            requestDetail = new RequestDetail();
            validator = new RequestDetailValidator();
            results = new ValidationResult();
        }

        [Test]
        public void Should_RequestDetailValidator_NotEmpty_Field()
        {
            requestDetail.RequestType = new RequestType();
            results = validator.Validate(requestDetail);
            Assert.IsFalse(results.IsValid);

            requestDetail.Quantity = 1;
            requestDetail.RequestType.RequestTypeID = 193;
            results = validator.Validate(requestDetail);
            Assert.IsTrue(results.IsValid);
        }

        [Test]
        public void Should_RequestDetailValidator_Quantity_GreaterThan_Zero()
        {
            requestDetail.RequestType = new RequestType();
            requestDetail.Quantity = 0;
            requestDetail.RequestType.RequestTypeID = 193;
            results = validator.Validate(requestDetail);
            Assert.IsFalse(results.IsValid);

            requestDetail.Quantity = 1;
            results = validator.Validate(requestDetail);
            Assert.IsTrue(results.IsValid);
        }
    }
}
