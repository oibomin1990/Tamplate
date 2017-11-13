using NUnit.Framework;

namespace MFU.Models.Tests
{
    [TestFixture]
    [Category("UnitTests.MFU.Models")]
    class RequestDetailTest
    {
        private RequestDetail requestDetail;

        [SetUp]
        public void SetUp()
        {
            requestDetail = new RequestDetail();
        }

        [Test]
        public void Should_RequestDetail_Calculate_Amount()
        {
            requestDetail.RequestType = new RequestType();
            requestDetail.RequestType.Price = 0;
            requestDetail.Quantity = 2;

            Assert.AreEqual(0, requestDetail.Amount);

            requestDetail.RequestType.Price = 100;
            requestDetail.Quantity = 2;

            Assert.AreEqual(200, requestDetail.Amount);
            Assert.AreNotEqual(300, requestDetail.Amount);
        }
    }
}
