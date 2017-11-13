using FluentValidation.Results;
using MFU.Models.ValidationRules;
using NUnit.Framework;

namespace MFU.Models.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Models.ValidatorRules")]
    class AddressValidatorTest
    {
        private Address address;
        private AddressValidator validator;
        private ValidationResult results;

        [SetUp]
        public void SetUp()
        {
            address = new Address();
            validator = new AddressValidator();
            results = new ValidationResult();
        }

        [Test]
        public void Should_AddressValidator_NotEmpty_Field()
        {
            results = validator.Validate(address);
            Assert.IsFalse(results.IsValid);

            address.ReceiveName = "Phanupong";
            address.Address1 = "123";
            address.MailingServiceType = 1;
            results = validator.Validate(address);
            Assert.IsTrue(results.IsValid);
        }
    }
}
