using FluentValidation.Results;
using MFU.Models.ValidationRules;
using NUnit.Framework;

namespace MFU.Models.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Models.ValidatorRules")]
    class RequestFeeValidatorTest
    {
        private RequestFee requestFee;
        private RequestFeeValidator validator;
        private ValidationResult results;

        [SetUp]
        public void SetUp()
        {
            requestFee = new RequestFee();
            validator = new RequestFeeValidator();
            results = new ValidationResult();
        }

        [Test]
        public void Should_RequestFeeValidator_NotEmpty_Field()
        {
            requestFee.RequestType = new RequestType();
            var result = validator.Validate(requestFee);
            Assert.IsFalse(result.IsValid);

            requestFee.FeeID = 3005;
            requestFee.Amount = 20;
            requestFee.Quantity = 1;
            requestFee.RequestType.RequestTypeID = 110;
            result = validator.Validate(requestFee);
            Assert.IsTrue(result.IsValid);
        }
    }
}
